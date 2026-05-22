using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SweetShellCup.Pages.Auth
{
    public class VerifyOtpModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập mã OTP.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Mã OTP phải có 6 chữ số.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Mã OTP chỉ bao gồm số.")]
        public string OtpInput { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IActionResult OnGet()
        {
            Email = HttpContext.Session.GetString("Reset_Email") ?? "";
            if (string.IsNullOrEmpty(Email))
            {
                return RedirectToPage("./ForgotPassword");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Email = HttpContext.Session.GetString("Reset_Email") ?? "";
            var sessionOtp = HttpContext.Session.GetString("Reset_OTP");
            var expiryStr = HttpContext.Session.GetString("Reset_Expiry");

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(sessionOtp) || string.IsNullOrEmpty(expiryStr))
            {
                return RedirectToPage("./ForgotPassword");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verify Expiry
            if (DateTime.TryParse(expiryStr, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime expiryTime))
            {
                if (DateTime.Now > expiryTime)
                {
                    ModelState.AddModelError(string.Empty, "Mã OTP đã hết hiệu lực. Vui lòng yêu cầu gửi lại mã mới.");
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("./ForgotPassword");
            }

            // Verify Code Match
            if (OtpInput.Trim() != sessionOtp.Trim())
            {
                ModelState.AddModelError(string.Empty, "Mã OTP không chính xác.");
                return Page();
            }

            // Success: Mark verification flag
            HttpContext.Session.SetString("Reset_Verified", "true");
            return RedirectToPage("./ResetPassword");
        }
    }
}
