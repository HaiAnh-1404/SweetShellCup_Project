using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _env;

        public EditModel(IProductRepository productRepo, ICategoryRepository categoryRepo, IWebHostEnvironment env)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _env = env;
        }

        [BindProperty]
        public Product EditProduct { get; set; } = default!;

        public SelectList CategoryOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var p = await _productRepo.GetByIdAsync(id.Value);
            if (p == null) return NotFound();

            EditProduct = p;
            
            var categories = await _categoryRepo.GetAllAsync();
            CategoryOptions = new SelectList(categories, "CategoryId", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? ImageFile)
        {
            ModelState.Remove("EditProduct.Category");

            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepo.GetAllAsync();
                CategoryOptions = new SelectList(categories, "CategoryId", "CategoryName");
                return Page();
            }
            
            var existing = await _productRepo.GetByIdAsync(EditProduct.ProductId);
            if (existing == null) return NotFound();
            
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "images", "products", fileName);
                
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "images", "products"));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                existing.ImageUrl = fileName;
            }

            existing.ProductName = EditProduct.ProductName;
            existing.CategoryId = EditProduct.CategoryId;
            existing.Price = EditProduct.Price;
            existing.Stock = EditProduct.Stock;
            existing.Flavor = EditProduct.Flavor;
            existing.Size = EditProduct.Size;
            existing.Description = EditProduct.Description;
            existing.Ingredients = EditProduct.Ingredients;
            
            await _productRepo.UpdateAsync(existing);

            TempData["Message"] = "Cập nhật sản phẩm thành công!";
            return RedirectToPage("./Index");
        }
    }
}
