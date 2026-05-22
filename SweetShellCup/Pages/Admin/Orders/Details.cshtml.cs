using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public DetailsModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Order { get; set; } = default!;

        public List<string> StatusList { get; } = new List<string>
        {
            "Pending",
            "Confirmed",
            "Packing",
            "Shipping",
            "Completed",
            "Cancelled"
        };

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            Order = order;
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int id, string status, string? carrier, string? tracking)
        {
            if (string.IsNullOrEmpty(status) || !StatusList.Contains(status))
            {
                TempData["ErrorMessage"] = "Trạng thái không hợp lệ.";
                return RedirectToPage("./Details", new { id });
            }

            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var fullAddress = order.ShippingAddress ?? "";
            var cleanAddress = fullAddress.Split("||")[0].Trim();
            string? updatedAddress = null;

            if (!string.IsNullOrEmpty(carrier) || !string.IsNullOrEmpty(tracking))
            {
                updatedAddress = $"{cleanAddress}||Carrier:{carrier?.Trim()}||Tracking:{tracking?.Trim()}";
            }
            else
            {
                updatedAddress = cleanAddress;
            }

            await _orderRepository.UpdateOrderStatusAsync(id, status, updatedAddress);
            TempData["Message"] = $"Đã cập nhật trạng thái đơn hàng #{id} thành {status}.";
            return RedirectToPage("./Details", new { id });
        }

        public async Task<IActionResult> OnPostConfirmPaymentAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var payment = order.Payments.FirstOrDefault();
            if (payment != null)
            {
                payment.PaymentStatus = "Paid";
                payment.PaidAt = System.DateTime.Now;
                await _orderRepository.UpdateOrderStatusAsync(id, order.Status ?? "Pending");
                TempData["Message"] = "Đã phê duyệt thanh toán thành công cho đơn hàng này.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin thanh toán.";
            }

            return RedirectToPage("./Details", new { id });
        }
    }
}
