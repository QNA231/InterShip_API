using InternShip_API.Handels.HandleEmail;

namespace InternShip_API.Services.Interfaces
{
    public interface IEmailServices
    {
        string SendEmail(EmailMessage emailMessage);
    }
}
