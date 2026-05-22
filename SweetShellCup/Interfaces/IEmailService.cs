using System.Threading.Tasks;

namespace SweetShellCup.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
