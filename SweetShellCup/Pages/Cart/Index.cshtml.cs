using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims;

namespace SweetShellCup.Pages.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICartRepository _cart;
        private readonly IOrderRepository _orders;

        public Models.Cart? UserCart { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
        public decimal TotalAmount { get; set; }

        [BindProperty]
        public string ShippingAddress { get; set; } = string.Empty;

        public IndexModel(ICartRepository cart, IOrderRepository orders)
        {
            _cart = cart;
            _orders = orders;
        }

        private int GetUserId()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
                return userId;
            return 0; 
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Giỏ hàng";
            ViewData["ActivePage"] = "Cart";

            UserCart = await _cart.GetCartByUserIdAsync(GetUserId());
            if (UserCart != null)
            {
                CartItems = (await _cart.GetCartItemsAsync(UserCart.CartId)).ToList();
                TotalAmount = CartItems.Sum(ci => ci.Quantity * ci.Product!.Price);
            }
            ViewData["CartCount"] = CartItems.Sum(ci => ci.Quantity);
        }

        public async Task<IActionResult> OnPostRemoveAsync(int cartItemId)
        {
            await _cart.RemoveItemAsync(cartItemId);
            TempData["Message"] = "Đã xoá sản phẩm khỏi giỏ hàng.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int cartItemId, int quantity)
        {
            if (quantity <= 0)
                await _cart.RemoveItemAsync(cartItemId);
            else
                await _cart.UpdateQuantityAsync(cartItemId, quantity);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            UserCart = await _cart.GetCartByUserIdAsync(GetUserId());
            if (UserCart == null) return RedirectToPage();

            var items = (await _cart.GetCartItemsAsync(UserCart.CartId)).ToList();
            if (!items.Any()) return RedirectToPage();

            var address = string.IsNullOrWhiteSpace(ShippingAddress) ? "Hà Nội" : ShippingAddress;
            var order = await _orders.CreateOrderAsync(GetUserId(), address, items);
            TempData["OrderSuccess"] = $"Đặt hàng thành công! Mã đơn hàng: #{order.OrderId}";
            return RedirectToPage();
        }
    }
}
