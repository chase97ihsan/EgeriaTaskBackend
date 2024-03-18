
using EgeriaTaskBackend.Domain.RequsetPayloads;

namespace EgeriaTaskBackend.Business.EmailService
{
    public interface IEmailService:IBaseService
    {
        Task<bool> SendEmail(EmailPayload emailPayload);
    }
}