using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;

namespace SweetShellCup.Pages.Feedback
{
    public class IndexModel : PageModel
    {
        private readonly IReviewRepository _reviews;
        private readonly IProductRepository _products;
        private readonly ICartRepository _cart;
        private readonly IWebHostEnvironment _env;

        public List<Review> Reviews { get; set; } = new();
        public List<Product> Products { get; set; } = new();
        public double OverallRating { get; set; }

        [BindProperty] public int ProductId { get; set; }
        [BindProperty] public int Rating { get; set; } = 5;
        [BindProperty] public string? Comment { get; set; }

        public IndexModel(IReviewRepository reviews, IProductRepository products, ICartRepository cart, IWebHostEnvironment env)
        {
            _reviews = reviews;
            _products = products;
            _cart = cart;
            _env = env;
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

        public async Task<IActionResult> OnPostAsync(IFormFile? ImageFile)
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

                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "images", "reviews", fileName);
                    
                    Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "images", "reviews"));

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    review.ImageUrl = fileName;
                }

                await _reviews.AddAsync(review);
                TempData["Message"] = "Cảm ơn bạn đã chia sẻ đánh giá!";
            }
            return RedirectToPage();
        }
    }
}
