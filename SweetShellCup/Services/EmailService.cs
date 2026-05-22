using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SweetShellCup.Interfaces;

namespace SweetShellCup.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // 🔴 ĐÂY LÀ DÒNG THÊM MỚI: Ép hệ thống sử dụng giao thức bảo mật TLS 1.2 và TLS 1.3 để Gmail chấp nhận kết nối
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var smtpServer = _configuration["EmailSettings:SmtpServer"] ?? "smtp.gmail.com";
            var portStr = _configuration["EmailSettings:Port"] ?? "587";
            var senderName = _configuration["EmailSettings:SenderName"] ?? "Sweet Shell Cup";
            var senderEmail = _configuration["EmailSettings:SenderEmail"] ?? "placeholder@gmail.com";
            var username = _configuration["EmailSettings:Username"] ?? "placeholder@gmail.com";
            var password = _configuration["EmailSettings:Password"] ?? "placeholder_password";

            if (!int.TryParse(portStr, out int port))
            {
                port = 587;
            }

            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(senderEmail, senderName);
                    message.To.Add(new MailAddress(toEmail));
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient(smtpServer, port))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(username, password);
                        client.EnableSsl = true;

                        await client.SendMailAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // In chi tiết lỗi gốc ra Terminal để bạn dễ kiểm tra nếu cấu hình appsettings bị sai
                Console.WriteLine($"\n=============================================");
                Console.WriteLine($"[EMAIL ERROR]: Thất bại khi gửi tới {toEmail}.");
                Console.WriteLine($"Chi tiết lỗi: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Lỗi gốc (Inner): {ex.InnerException.Message}");
                }
                Console.WriteLine($"=============================================\n");

                return;
            }
        }
    }
}