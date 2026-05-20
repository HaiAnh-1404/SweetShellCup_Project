using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _products;
        private readonly ICartRepository _cart;

        // Demo: UserId = 2 (Customer)
        private const int DemoUserId = 2;

        public List<Product> FeaturedProducts { get; set; } = new();

        public IndexModel(IProductRepository products, ICartRepository cart)
        {
            _products = products;
            _cart = cart;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Trang chủ";
            ViewData["ActivePage"] = "Home";
            ViewData["CartCount"] = await _cart.GetCartItemCountAsync(DemoUserId);

            var all = await _products.GetAllAsync();
            FeaturedProducts = all.Take(4).ToList();
        }
    }
}
