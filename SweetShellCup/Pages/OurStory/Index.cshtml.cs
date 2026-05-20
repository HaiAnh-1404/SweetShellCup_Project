using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;

namespace SweetShellCup.Pages.OurStory
{
    public class IndexModel : PageModel
    {
        private readonly ICartRepository _cart;
        private const int DemoUserId = 2;

        public IndexModel(ICartRepository cart) { _cart = cart; }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Câu chuyện của chúng tôi";
            ViewData["ActivePage"] = "OurStory";
            ViewData["CartCount"] = await _cart.GetCartItemCountAsync(DemoUserId);
        }
    }
}
