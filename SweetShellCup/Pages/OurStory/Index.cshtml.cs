using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using System.Security.Claims;

namespace SweetShellCup.Pages.OurStory
{
    public class IndexModel : PageModel
    {
        private readonly ICartRepository _cart;

        public IndexModel(ICartRepository cart) { _cart = cart; }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Câu chuyện của chúng tôi";
            ViewData["ActivePage"] = "OurStory";

            int cartCount = 0;
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdString, out var userId))
            {
                cartCount = await _cart.GetCartItemCountAsync(userId);
            }
            ViewData["CartCount"] = cartCount;
        }
    }
}
