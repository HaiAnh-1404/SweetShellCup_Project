using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public CreateModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public User NewUser { get; set; } = new();

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; } = null!;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng xác nhận Mật khẩu.")]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; } = null!;

        public SelectList RoleOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var roles = await _userRepository.GetAllRolesAsync();
            RoleOptions = new SelectList(roles, "RoleId", "RoleName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("NewUser.Role");
            ModelState.Remove("NewUser.PasswordHash");

            if (!ModelState.IsValid)
            {
                var roles = await _userRepository.GetAllRolesAsync();
                RoleOptions = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(NewUser.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("NewUser.Email", "Email này đã được sử dụng.");
                var roles = await _userRepository.GetAllRolesAsync();
                RoleOptions = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

            NewUser.PasswordHash = Password;
            NewUser.CreatedAt = DateTime.Now;

            await _userRepository.AddUserAsync(NewUser);

            TempData["Message"] = "Thêm tài khoản thành công!";
            return RedirectToPage("./Index");
        }
    }
}
