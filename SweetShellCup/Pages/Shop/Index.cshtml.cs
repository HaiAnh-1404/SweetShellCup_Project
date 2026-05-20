using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _products;
        private readonly ICategoryRepository _categories;
        private readonly ICartRepository _cart;
        private const int DemoUserId = 2;

        public List<Product> Products { get; set; } = new();
        public List<Category> Categories { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? CategoryFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public IndexModel(IProductRepository products, ICategoryRepository categories, ICartRepository cart)
        {
            _products = products;
            _categories = categories;
            _cart = cart;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Cửa hàng";
            ViewData["ActivePage"] = "Shop";
            ViewData["CartCount"] = await _cart.GetCartItemCountAsync(DemoUserId);

            Categories = (await _categories.GetAllAsync()).ToList();

            if (!string.IsNullOrWhiteSpace(Search))
                Products = (await _products.SearchAsync(Search)).ToList();
            else if (CategoryFilter.HasValue)
                Products = (await _products.GetByCategoryAsync(CategoryFilter.Value)).ToList();
            else
                Products = (await _products.GetAllAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            await _cart.AddItemAsync(DemoUserId, productId, 1);
            TempData["Message"] = "Đã thêm vào giỏ hàng!";
            return RedirectToPage();
        }
    }
}
