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
        private readonly IUserRepository _users;

        public Models.Cart? UserCart { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
        public decimal TotalAmount { get; set; }

        [BindProperty]
        public string ShippingAddress { get; set; } = string.Empty;

        [BindProperty]
        public string PhoneNumber { get; set; } = string.Empty;

        [BindProperty]
        public int PaymentMethodId { get; set; } = 1;

        public IndexModel(ICartRepository cart, IOrderRepository orders, IUserRepository users)
        {
            _cart = cart;
            _orders = orders;
            _users = users;
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

            var userId = GetUserId();
            UserCart = await _cart.GetCartByUserIdAsync(userId);
            if (UserCart != null)
            {
                CartItems = (await _cart.GetCartItemsAsync(UserCart.CartId)).ToList();
                TotalAmount = CartItems.Sum(ci => ci.Quantity * ci.Product!.Price);
            }
            ViewData["CartCount"] = CartItems.Sum(ci => ci.Quantity);

            // Pre-populate address and phone from user profile
            var user = await _users.GetUserByIdAsync(userId);
            if (user != null)
            {
                if (string.IsNullOrEmpty(ShippingAddress))
                    ShippingAddress = user.Address ?? string.Empty;
                if (string.IsNullOrEmpty(PhoneNumber))
                    PhoneNumber = user.Phone ?? string.Empty;
            }
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
            var userId = GetUserId();
            UserCart = await _cart.GetCartByUserIdAsync(userId);
            if (UserCart == null) return RedirectToPage();

            var items = (await _cart.GetCartItemsAsync(UserCart.CartId)).ToList();
            if (!items.Any()) return RedirectToPage();

            // Update user details if provided
            var user = await _users.GetUserByIdAsync(userId);
            if (user != null)
            {
                bool needUpdate = false;
                if (!string.IsNullOrWhiteSpace(PhoneNumber) && user.Phone != PhoneNumber)
                {
                    user.Phone = PhoneNumber;
                    needUpdate = true;
                }
                if (!string.IsNullOrWhiteSpace(ShippingAddress) && user.Address != ShippingAddress)
                {
                    user.Address = ShippingAddress;
                    needUpdate = true;
                }
                if (needUpdate)
                {
                    await _users.UpdateUserAsync(user);
                }
            }

            var address = string.IsNullOrWhiteSpace(ShippingAddress) ? "Hà Nội" : ShippingAddress;
            var order = await _orders.CreateOrderAsync(userId, address, items, PaymentMethodId);
            TempData["OrderSuccess"] = $"Đặt hàng thành công! Mã đơn hàng: #{order.OrderId}";
            return RedirectToPage("/Customer/Orders/Details", new { id = order.OrderId });
        }
    }
}
