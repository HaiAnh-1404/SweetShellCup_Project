using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepo;

        public IndexModel(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<Product> ProductsList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ProductsList = await _productRepo.GetAllAsync();
        }
    }
}
