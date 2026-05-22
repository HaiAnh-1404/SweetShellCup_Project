using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;

namespace SweetShellCup.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải chứa ít nhất 6 ký tự.")]
        public string Password { get; set; } = null!;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu mới.")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        public string ConfirmPassword { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IActionResult OnGet()
        {
            Email = HttpContext.Session.GetString("Reset_Email") ?? "";
            var isVerified = HttpContext.Session.GetString("Reset_Verified") ?? "false";

            if (string.IsNullOrEmpty(Email) || isVerified != "true")
            {
                return RedirectToPage("./ForgotPassword");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Email = HttpContext.Session.GetString("Reset_Email") ?? "";
            var isVerified = HttpContext.Session.GetString("Reset_Verified") ?? "false";

            if (string.IsNullOrEmpty(Email) || isVerified != "true")
            {
                return RedirectToPage("./ForgotPassword");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userRepository.GetUserByEmailAsync(Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy thông tin tài khoản người dùng.");
                return Page();
            }

            // Update user password - following current plain text representation used in LoginModel
            user.PasswordHash = Password;
            await _userRepository.UpdateUserAsync(user);

            // Clean up session keys
            HttpContext.Session.Remove("Reset_Email");
            HttpContext.Session.Remove("Reset_OTP");
            HttpContext.Session.Remove("Reset_Expiry");
            HttpContext.Session.Remove("Reset_Verified");

            TempData["Message"] = "Khôi phục mật khẩu thành công. Vui lòng đăng nhập với mật khẩu mới.";
            return RedirectToPage("./Login");
        }
    }
}
