using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;

namespace SweetShellCup.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ForgotPasswordModel(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; } = null!;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userRepository.GetUserByEmailAsync(Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email không tồn tại trong hệ thống.");
                return Page();
            }

            // Generate OTP code
            var otpCode = new Random().Next(100000, 999999).ToString();

            // Store in Session
            HttpContext.Session.SetString("Reset_Email", Email);
            HttpContext.Session.SetString("Reset_OTP", otpCode);
            HttpContext.Session.SetString("Reset_Expiry", DateTime.Now.AddMinutes(5).ToString("O"));
            HttpContext.Session.SetString("Reset_Verified", "false");

            // Developer experience print to Console
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"[RESET PASSWORD OTP FOR {Email}]: {otpCode}");
            Console.WriteLine("=============================================\n");

            try
            {
                var subject = "Mã OTP khôi phục mật khẩu - Sweet Shell Cup";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #fdd6ea; border-radius: 12px; background: #fff0f7; max-width: 500px; margin: auto;'>
                        <h2 style='color: #533931; text-align: center;'>Mã Xác Thực OTP</h2>
                        <p style='color: #533931; font-size: 15px;'>Chào bạn,</p>
                        <p style='color: #533931; font-size: 15px;'>Bạn nhận được email này vì đã yêu cầu khôi phục mật khẩu tại <strong>Sweet Shell Cup</strong>.</p>
                        <div style='text-align: center; margin: 30px 0;'>
                            <span style='background: #e60380; color: #fff; padding: 12px 24px; font-size: 24px; font-weight: bold; border-radius: 8px; letter-spacing: 4px;'>{otpCode}</span>
                        </div>
                        <p style='color: #e60380; font-size: 13px; font-weight: 600; text-align: center;'>Mã OTP này có hiệu lực trong vòng 5 phút.</p>
                        <p style='color: #888; font-size: 12px; margin-top: 30px; text-align: center; border-top: 1px solid #fdd6ea; padding-top: 15px;'>Nếu bạn không yêu cầu hành động này, vui lòng bỏ qua email.</p>
                    </div>";

                await _emailService.SendEmailAsync(Email, subject, body);
            }
            catch (Exception ex)
            {
                // Email gửi thất bại - thông báo rõ cho user
                Console.WriteLine($"[ForgotPassword] Email gửi thất bại: {ex.Message}");
                ModelState.AddModelError(string.Empty,
                    "Không thể gửi email OTP. Vui lòng kiểm tra lại email hoặc thử lại sau. " +
                    "(Nếu đang chạy ở môi trường dev, mã OTP đã được in ra Terminal.)");
                return Page();
            }

            return RedirectToPage("./VerifyOtp");
        }
    }
}
