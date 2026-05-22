using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.IO;
using System.Linq;
using System.Security.Claims; // THÊM DÒNG NÀY

namespace SweetShellCup.Pages.Customer.Orders
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        // ĐÃ XÓA DÒNG: private const int DemoUserId = 2;

        public DetailsModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Order { get; set; } = default!;

        [BindProperty]
        public IFormFile? ReceiptFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            // Lấy UserId thực tế từ người dùng đang đăng nhập
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Forbid();
            }

            // Chuyển đổi sang int nếu database dùng int
            if (!int.TryParse(userIdClaim, out int currentUserId))
            {
                return Forbid();
            }

            // Kiểm tra đơn hàng thuộc đúng người dùng hiện tại
            if (order.UserId != currentUserId)
            {
                return Forbid();
            }

            ViewData["Title"] = $"Đơn hàng #{order.OrderId}";
            ViewData["ActivePage"] = "Orders";

            Order = order;

            return Page();
        }

        public async Task<IActionResult> OnPostUploadReceiptAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            // Lấy UserId thực tế từ người dùng đang đăng nhập
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Forbid();
            }

            if (!int.TryParse(userIdClaim, out int currentUserId))
            {
                return Forbid();
            }

            // Kiểm tra đơn hàng thuộc đúng người dùng hiện tại
            if (order.UserId != currentUserId)
            {
                return Forbid();
            }

            if (ReceiptFile == null || ReceiptFile.Length == 0)
            {
                TempData["ErrorMessage"] =
                    "Vui lòng chọn một tệp hình ảnh để tải lên.";

                return RedirectToPage("./Details", new { id });
            }

            var ext = Path.GetExtension(ReceiptFile.FileName)
                .ToLowerInvariant();

            if (ext != ".png" &&
                ext != ".jpg" &&
                ext != ".jpeg")
            {
                TempData["ErrorMessage"] =
                    "Chỉ chấp nhận tệp hình ảnh (.png, .jpg, .jpeg).";

                return RedirectToPage("./Details", new { id });
            }

            if (ReceiptFile.Length > 5 * 1024 * 1024)
            {
                TempData["ErrorMessage"] =
                    "Dung lượng hình ảnh không được vượt quá 5MB.";

                return RedirectToPage("./Details", new { id });
            }

            var uploadsDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                "receipts");

            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }

            var fileName = $"receipt_{id}{ext}";

            var filePath = Path.Combine(
                uploadsDir,
                fileName);

            using (var stream = new FileStream(
                filePath,
                FileMode.Create))
            {
                await ReceiptFile.CopyToAsync(stream);
            }

            var payment = order.Payments.FirstOrDefault();

            if (payment != null &&
                payment.PaymentStatus != "Paid")
            {
                payment.PaymentStatus = "Pending";

                await _orderRepository.UpdateOrderStatusAsync(
                    id,
                    order.Status ?? "Pending");
            }

            TempData["Message"] =
                "Đã tải lên biên lai thành công. Đang chờ Admin phê duyệt thanh toán.";

            return RedirectToPage("./Details", new { id });
        }
    }
}