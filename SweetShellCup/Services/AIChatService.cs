using Microsoft.EntityFrameworkCore;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SweetShellCup.Services
{
    public class AIChatService : IAIChatService
    {
        private readonly HttpClient _http;
        private readonly SweetShellCupDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<AIChatService> _logger;

        public AIChatService(
            HttpClient http,
            SweetShellCupDbContext context,
            IConfiguration config,
            ILogger<AIChatService> logger)
        {
            _http = http;
            _context = context;
            _config = config;
            _logger = logger;
        }

        public async Task<ChatResponse> AskAsync(string userMessage, List<ChatMessage>? history = null)
        {
            try
            {
                // 1) Build system prompt từ data DB
                var systemPrompt = await BuildSystemPromptAsync();

                // 2) Tổ chức messages
                var messages = new List<object>
                {
                    new { role = "system", content = systemPrompt }
                };

                if (history != null)
                {
                    foreach (var m in history.TakeLast(10)) // giới hạn 10 turn gần nhất
                        messages.Add(new { role = m.Role, content = m.Content });
                }

                messages.Add(new { role = "user", content = userMessage });

                // 3) Tạo payload
                var payload = new
                {
                    model = _config["AI:Model"],
                    messages,
                    temperature = _config.GetValue<double>("AI:Temperature", 0.7),
                    max_tokens = _config.GetValue<int>("AI:MaxTokens", 700)
                };

                var json = JsonSerializer.Serialize(payload);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 4) Set Authorization header
                var apiKey = _config["AI:ApiKey"];
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);

                // 5) Gọi API
                var endpoint = _config["AI:Endpoint"]
                    ?? "https://api.groq.com/openai/v1/chat/completions";

                var response = await _http.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    var err = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Groq API error {Status}: {Body}", response.StatusCode, err);
                    return new ChatResponse
                    {
                        Success = false,
                        Error = $"AI API error: {response.StatusCode}",
                        Reply = "Xin lỗi, AI đang bận. Bạn thử lại sau ít phút nhé 😅"
                    };
                }

                // 6) Parse response
                var body = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);
                var reply = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "";

                return new ChatResponse { Reply = reply.Trim(), Success = true };
            }
            catch (TaskCanceledException)
            {
                return new ChatResponse
                {
                    Success = false,
                    Error = "Timeout",
                    Reply = "AI đang phản hồi chậm, bạn thử lại nhé ⏱️"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AIChatService error");
                return new ChatResponse
                {
                    Success = false,
                    Error = ex.Message,
                    Reply = "Đã có lỗi xảy ra. Vui lòng thử lại."
                };
            }
        }

        /// <summary>
        /// Build system prompt với context động từ database
        /// </summary>
        private async Task<string> BuildSystemPromptAsync()
        {
            // Top vị bán chạy
            var topFlavors = await _context.OrderDetails
                .Where(od => od.Product.Flavor != null && od.Product.Flavor != "")
                .GroupBy(od => od.Product.Flavor)
                .Select(g => new { Flavor = g.Key, Sold = g.Sum(od => od.Quantity) })
                .OrderByDescending(x => x.Sold)
                .Take(10)
                .ToListAsync();

            // Top sản phẩm bán chạy
            var topProducts = await _context.OrderDetails
                .GroupBy(od => new
                {
                    od.ProductId,
                    od.Product.ProductName,
                    od.Product.Price,
                    od.Product.Flavor
                })
                .Select(g => new
                {
                    g.Key.ProductName,
                    g.Key.Price,
                    g.Key.Flavor,
                    Sold = g.Sum(od => od.Quantity)
                })
                .OrderByDescending(x => x.Sold)
                .Take(10)
                .ToListAsync();

            // Toàn bộ sản phẩm (catalog nhỏ nên đưa hết vào)
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new
                {
                    p.ProductName,
                    p.Flavor,
                    p.Size,
                    p.Price,
                    p.Stock,
                    Category = p.Category!.CategoryName
                })
                .ToListAsync();

            var sb = new StringBuilder();
            sb.AppendLine("Bạn là 'Sweet Shell Bot' — trợ lý AI của Sweet Shell Cup, shop bán cốc waffle ăn được tại Việt Nam.");
            sb.AppendLine();
            sb.AppendLine("PHONG CÁCH:");
            sb.AppendLine("- Thân thiện, vui vẻ, dùng emoji phù hợp (🍦🌟🏆🔥).");
            sb.AppendLine("- Trả lời NGẮN GỌN bằng tiếng Việt (tối đa 4-5 dòng trừ khi user yêu cầu chi tiết).");
            sb.AppendLine("- Có thể dùng HTML đơn giản: <b>, <i>, <br/> để format. KHÔNG dùng markdown.");
            sb.AppendLine("- Giá tiền format dạng: 45.000đ");
            sb.AppendLine();
            sb.AppendLine("QUY TẮC:");
            sb.AppendLine("- CHỈ dùng dữ liệu bên dưới, TUYỆT ĐỐI không bịa thông tin sản phẩm/giá.");
            sb.AppendLine("- Nếu user hỏi ngoài phạm vi shop (chính trị, code, học bài…), lịch sự từ chối và gợi ý quay lại chủ đề sản phẩm.");
            sb.AppendLine("- Nếu không tìm thấy dữ liệu, nói thẳng \"Mình chưa có thông tin về cái này\".");
            sb.AppendLine();
            sb.AppendLine("========== DỮ LIỆU SHOP (CẬP NHẬT REAL-TIME) ==========");
            sb.AppendLine();

            sb.AppendLine("🏆 TOP VỊ BÁN CHẠY NHẤT:");
            if (topFlavors.Count == 0)
                sb.AppendLine("(Chưa có dữ liệu bán hàng)");
            else
                for (int i = 0; i < topFlavors.Count; i++)
                    sb.AppendLine($"{i + 1}. {topFlavors[i].Flavor}: đã bán {topFlavors[i].Sold} sản phẩm");
            sb.AppendLine();

            sb.AppendLine("🔥 TOP SẢN PHẨM BÁN CHẠY:");
            for (int i = 0; i < topProducts.Count; i++)
            {
                var p = topProducts[i];
                sb.AppendLine($"{i + 1}. {p.ProductName} (vị {p.Flavor}, {p.Price:N0}đ) - đã bán {p.Sold}");
            }
            sb.AppendLine();

            sb.AppendLine("📦 DANH MỤC SẢN PHẨM:");
            foreach (var p in products)
            {
                sb.AppendLine($"- {p.ProductName} | Vị: {p.Flavor} | Size: {p.Size} | Giá: {p.Price:N0}đ | Tồn kho: {p.Stock} | Danh mục: {p.Category}");
            }

            return sb.ToString();
        }
    }
}