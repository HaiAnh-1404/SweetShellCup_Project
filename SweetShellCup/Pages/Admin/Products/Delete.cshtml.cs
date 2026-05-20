using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepo;

        public DeleteModel(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var p = await _productRepo.GetByIdAsync(id.Value);
            if (p == null) return NotFound();

            await _productRepo.DeleteAsync(id.Value);
            TempData["Message"] = "Đã xóa sản phẩm thành công!";
            return RedirectToPage("./Index");
        }
    }
}
