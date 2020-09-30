using lab.DataStore.App.BLL;
using lab.DataStore.App.EmailSender;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private readonly EmailSenderManager _emailSenderManager;

        public AuthMessageSender()
        {
            _emailSenderManager = new EmailSenderManager();
        }

        public Task SendEmailAsync(string userId, string name, string email, string subject, string message)
        {
            // Plug in your email service here to send an email.

            EmailMessage emailMessage = new EmailMessage();
            emailMessage.ReceiverName = name;
            emailMessage.ReceiverEmail = email;
            emailMessage.Subject = subject;
            emailMessage.IsHtml = true;
            emailMessage.Body = message;

            _emailSenderManager.SendEmailMessage(emailMessage, userId);

            return Task.FromResult(0);
        }

        public Task SendEmailAsync(string userId, string email, string subject, string message)
        {
            // Plug in your email service here to send an email.

            EmailMessage emailMessage = new EmailMessage();
            emailMessage.ReceiverName = string.Empty;
            emailMessage.ReceiverEmail = email;
            emailMessage.Subject = subject;
            emailMessage.IsHtml = true;
            emailMessage.Body = message;

            _emailSenderManager.SendEmailMessage(emailMessage, userId);

            return Task.FromResult(0);
        }

        public async Task SendEmailBySendGridAsync(string userId, string email, string subject, string message)
        {
            // Plug in your email service here to send an email.

            EmailMessage emailMessage = new EmailMessage();
            emailMessage.ReceiverName = string.Empty;
            emailMessage.ReceiverEmail = email;
            emailMessage.Subject = subject;
            emailMessage.IsHtml = true;
            emailMessage.Body = message;

            await _emailSenderManager.SendEmailMessageBySendGridAsync(emailMessage, userId);
        }

        public async Task SendEmailBySendGridAsync(string userId, List<string> emailList, string subject, string message)
        {
            // Plug in your email service here to send an email.

            List<EmailMessage> emailMessageList = new List<EmailMessage>();

            if (emailList.Any())
            {
                foreach (var email in emailList)
                {
                    EmailMessage emailMessage = new EmailMessage();
                    emailMessage.ReceiverName = string.Empty;
                    emailMessage.ReceiverEmail = email;
                    emailMessage.Subject = subject;
                    emailMessage.IsHtml = true;
                    emailMessage.Body = message;

                    emailMessageList.Add(emailMessage);
                }

                await _emailSenderManager.SendEmailMessageBySendGridAsync(emailMessageList, userId);
            }
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string userId, string name, string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
