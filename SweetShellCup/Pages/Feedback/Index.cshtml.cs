using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims;

namespace SweetShellCup.Pages.Feedback
{
    public class IndexModel : PageModel
    {
        private readonly IReviewRepository _reviews;
        private readonly IProductRepository _products;
        private readonly ICartRepository _cart;

        public List<Review> Reviews { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        public double OverallRating { get; set; }

        [BindProperty] public int ProductId { get; set; }
        [BindProperty] public int Rating { get; set; } = 5;
        [BindProperty] public string? Comment { get; set; }

        public IndexModel(IReviewRepository reviews, IProductRepository products, ICartRepository cart)
        {
            _reviews = reviews;
            _products = products;
            _cart = cart;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Đánh giá";
            ViewData["ActivePage"] = "Feedback";

            int cartCount = 0;
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
            {
                cartCount = await _cart.GetCartItemCountAsync(userId);
            }
            ViewData["CartCount"] = cartCount;

            Reviews = (await _reviews.GetAllAsync()).ToList();
            Products = (await _products.GetAllAsync()).Take(10).ToList();
            OverallRating = Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Auth/Login");
            }

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
            {
                var review = new Review
                {
                    UserId = userId,
                    ProductId = ProductId,
                    Rating = Rating,
                    Comment = Comment,
                    CreatedAt = DateTime.Now
                };
                await _reviews.AddAsync(review);
                TempData["Message"] = "Cảm ơn bạn đã chia sẻ đánh giá!";
            }
            return RedirectToPage();
        }
    }
}
