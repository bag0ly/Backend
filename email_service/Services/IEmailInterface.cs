using email_service.Models;

namespace email_service.Services
{
    public interface IEmailInterface
    {
        void SendEmail(EmailDTO request);
    }
}
