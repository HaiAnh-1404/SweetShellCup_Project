using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims; // THÊM DÒNG NÀY

namespace SweetShellCup.Pages.Customer.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        // ĐÃ XÓA DÒNG: private const int DemoUserId = 2;

        public IEnumerable<Order> OrdersList { get; set; } = new List<Order>();

        public IndexModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Đơn hàng của tôi";
            ViewData["ActivePage"] = "Orders";

            // Lấy UserId thực tế từ người dùng đang đăng nhập
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out int currentUserId))
            {
                // Lấy đơn hàng của người dùng hiện tại
                OrdersList = await _orderRepository.GetByUserIdAsync(currentUserId);
            }
            else
            {
                // Nếu không lấy được UserId, trả về danh sách rỗng
                OrdersList = new List<Order>();

                // Optional: Thêm thông báo nếu muốn
                // TempData["ErrorMessage"] = "Không thể xác định tài khoản của bạn.";
            }
        }
    }
}