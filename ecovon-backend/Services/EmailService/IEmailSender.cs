using System.Threading.Tasks;

namespace ecovon_backend.Services.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}