using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập Họ và tên.")]
        public string FullName { get; set; } = null!;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; } = null!;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; } = null!;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng xác nhận Mật khẩu.")]
        [Compare(nameof(Password), ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; } = null!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingUser = await _userRepository.GetUserByEmailAsync(Email);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email này đã được sử dụng.");
                return Page();
            }

            var role = await _userRepository.GetRoleByNameAsync("Customer");
            var roleId = role?.RoleId ?? 2; // Default Customer role id if not found

            var newUser = new User
            {
                FullName = FullName,
                Email = Email,
                PasswordHash = Password, // Use hash in real app
                RoleId = roleId,
                CreatedAt = DateTime.Now
            };

            await _userRepository.AddUserAsync(newUser);
            
            TempData["Message"] = "Đăng ký thành công! Vui lòng đăng nhập.";
            return RedirectToPage("/Auth/Login");
        }
    }
}
