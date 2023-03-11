using Ira.Services.Model;

namespace Ira.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
