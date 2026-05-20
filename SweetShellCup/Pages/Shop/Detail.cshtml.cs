using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims;

namespace SweetShellCup.Pages.Shop
{
    public class DetailModel : PageModel
    {
        private readonly IProductRepository _products;
        private readonly ICartRepository _cart;
        private readonly IReviewRepository _reviews;

        public Product? Product { get; set; }
        public List<Review> Reviews { get; set; } = new();
        public double AverageRating { get; set; }

        [BindProperty]
        public int Rating { get; set; } = 5;
        [BindProperty]
        public string? Comment { get; set; }

        public DetailModel(IProductRepository products, ICartRepository cart, IReviewRepository reviews)
        {
            _products = products;
            _cart = cart;
            _reviews = reviews;
        }

        private int GetUserId()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
                return userId;
            return 0;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _products.GetByIdAsync(id);
            if (Product == null) return NotFound();

            ViewData["Title"] = Product.ProductName;
            ViewData["ActivePage"] = "Shop";
            
            var userId = GetUserId();
            ViewData["CartCount"] = userId > 0 ? await _cart.GetCartItemCountAsync(userId) : 0;

            Reviews = (await _reviews.GetByProductIdAsync(id)).ToList();
            AverageRating = Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int id, int quantity = 1)
        {
            var userId = GetUserId();
            if (userId == 0) return RedirectToPage("/Auth/Login");

            await _cart.AddItemAsync(userId, id, quantity);
            TempData["Message"] = "Đã thêm vào giỏ hàng!";
            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostSubmitReviewAsync(int id)
        {
            var userId = GetUserId();
            if (userId == 0) return RedirectToPage("/Auth/Login");

            var review = new Review
            {
                UserId = userId,
                ProductId = id,
                Rating = Rating,
                Comment = Comment,
                CreatedAt = DateTime.Now
            };
            await _reviews.AddAsync(review);
            TempData["ReviewMessage"] = "Cảm ơn bạn đã đánh giá!";
            return RedirectToPage(new { id });
        }
    }
}
