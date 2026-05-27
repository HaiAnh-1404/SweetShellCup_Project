using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims;

namespace SweetShellCup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _products;
        private readonly ICartRepository _cart;
        private readonly IAIChatService _ai;        // ← thêm

        public List<Product> FeaturedProducts { get; set; } = new();

        public IndexModel(
            IProductRepository products,
            ICartRepository cart,
            IAIChatService ai)                      // ← thêm
        {
            _products = products;
            _cart = cart;
            _ai = ai;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Trang chủ";
            ViewData["ActivePage"] = "Home";

            int cartCount = 0;
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
            {
                cartCount = await _cart.GetCartItemCountAsync(userId);
            }
            ViewData["CartCount"] = cartCount;

            var all = await _products.GetAllAsync();
            FeaturedProducts = all.Take(4).ToList();
        }

        // ===== Handler cho chatbot AI =====
        public async Task<JsonResult> OnPostChatAsync([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Message))
                return new JsonResult(new { reply = "Bạn chưa nhập câu hỏi 😊" });

            var result = await _ai.AskAsync(request.Message, request.History);
            return new JsonResult(new { reply = result.Reply, success = result.Success });
        }
    }
}