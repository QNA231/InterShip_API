using InternShip_API.Handels.HandleEmail;
using InternShip_API.PayLoads.Responses;
using InternShip_API.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace InternShip_API.Services.Implements
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfiguration configuration;

        public EmailServices(EmailConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string SendEmail(EmailMessage emailMessage)
        {
            var message = CreateEmailMessage(emailMessage);
            Send(message);
            var recipients = string.Join(", ", message.To);
            return ResponseMessage.GetEmailMessage(recipients);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content};
            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", configuration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(configuration.UserName, configuration.Password);
                client.Send(message);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
