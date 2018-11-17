using System.Threading.Tasks;

namespace ecovon_backend.Services.EmailService
{
    internal interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}