using BlogApi.Models.Dtos;

namespace BlogApi.Repositories
{
    public interface IEmailInterface
    {
        void SendEmail(EmailDTO request);
    }
}
