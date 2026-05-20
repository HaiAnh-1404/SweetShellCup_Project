using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IWebHostEnvironment _env;

        public CreateModel(IProductRepository productRepo, ICategoryRepository categoryRepo, IWebHostEnvironment env)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _env = env;
        }

        [BindProperty]
        public Product NewProduct { get; set; } = default!;

        public SelectList CategoryOptions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            CategoryOptions = new SelectList(categories, "CategoryId", "CategoryName");
        }

        public async Task<IActionResult> OnPostAsync(IFormFile? ImageFile)
        {
            ModelState.Remove("NewProduct.Category");
            
            if (!ModelState.IsValid)
            {
                var categories = await _categoryRepo.GetAllAsync();
                CategoryOptions = new SelectList(categories, "CategoryId", "CategoryName");
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "images", "products", fileName);
                
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "images", "products"));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                NewProduct.ImageUrl = fileName;
            }

            NewProduct.CreatedAt = DateTime.Now;
            await _productRepo.AddAsync(NewProduct);

            TempData["Message"] = "Thêm sản phẩm thành công!";
            return RedirectToPage("./Index");
        }
    }
}
