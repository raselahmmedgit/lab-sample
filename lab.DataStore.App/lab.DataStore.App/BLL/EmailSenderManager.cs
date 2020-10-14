using lab.DataStore.App.EmailSender;
using lab.DataStore.App.Helper;
using log4net;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace lab.DataStore.App.BLL
{
    public class EmailSenderManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EmailSenderManager));
        private static IConfiguration _configuration;
        private static EmailConfiguration _emailConfiguration;
        private static SendGridConfiguration _sendGridConfiguration;

        public EmailSenderManager()
        {
        }

        public EmailSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _emailConfiguration = new EmailConfiguration();
            _emailConfiguration.FromEmailAddress = _configuration["AppEmailConfig:FromEmailAddressKey"]?.ToString();
            _emailConfiguration.DisplayName = _configuration["AppEmailConfig:DisplayNameKey"]?.ToString();
            _emailConfiguration.Password = _configuration["AppEmailConfig:PasswordKey"]?.ToString();
            _emailConfiguration.Host = _configuration["AppEmailConfig:HostKey"]?.ToString();
            _emailConfiguration.Port = Int32.Parse(_configuration["AppEmailConfig:PortKey"]);
            _emailConfiguration.Ssl = Boolean.Parse(_configuration["AppEmailConfig:SslKey"]);
            log.Debug("EmailSenderManager - EmailConfiguration - Username: " + _emailConfiguration.FromEmailAddress);
            log.Debug("EmailSenderManager - EmailConfiguration - Password: " + _emailConfiguration.Password);

            _sendGridConfiguration = new SendGridConfiguration();
            _sendGridConfiguration.FromEmailAddress = _configuration["AppEmailConfig:SendGridFromEmailAddressKey"]?.ToString();
            _sendGridConfiguration.DisplayName = _configuration["AppEmailConfig:SendGridDisplayNameKey"]?.ToString();
            _sendGridConfiguration.ApiKey = _configuration["AppEmailConfig:SendGridApiKey"]?.ToString();
            log.Debug("EmailSenderManager - SendGridConfiguration - SendGrid");
        }

        public EmailConfiguration GetEmailConfiguration()
        {
            if (_emailConfiguration != null)
            {
                return _emailConfiguration;
            }
            else
            {
                return null;
            }
        }

        public SendGridConfiguration GetSendGridConfiguration()
        {
            if (_sendGridConfiguration != null)
            {
                return _sendGridConfiguration;
            }
            else
            {
                return null;
            }
        }

        public EmailSentResult SendEmailMessage(EmailMessage emailMessage, string userId)
        {
            EmailConfiguration emailConfiguration = GetEmailConfiguration();
            EmailSentResult emailSentResult = new EmailSentResult() { Success = false };
            try
            {
                var smtp = new SmtpClient
                {
                    Host = emailConfiguration.Host,
                    Port = emailConfiguration.Port,
                    EnableSsl = emailConfiguration.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailConfiguration.FromEmailAddress, emailConfiguration.Password)
                };
                using (var smtpMessage = new MailMessage(new MailAddress(emailConfiguration.FromEmailAddress, emailConfiguration.DisplayName), new MailAddress(emailMessage.ReceiverEmail, emailMessage.ReceiverName)))
                {
                    smtpMessage.Subject = emailMessage.Subject;
                    smtpMessage.Body = emailMessage.Body;
                    smtpMessage.IsBodyHtml = emailMessage.IsHtml;
                    smtpMessage.Priority = MailPriority.High;
                    smtpMessage.SubjectEncoding = Encoding.UTF8;
                    smtpMessage.BodyEncoding = Encoding.UTF8;
                    smtpMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                    smtp.Send(smtpMessage);

                    emailSentResult.Success = true;
                    emailSentResult.Id = userId;
                    log.Info("EmailSenderManager - SendEmailMessage - Email send successfully for user id: " + userId + " email: " + emailMessage.ReceiverEmail);

                    smtp.Dispose();
                }
            }
            catch (Exception ex)
            {
                emailSentResult.Ex = ex;
                log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "SendEmailMessage", emailMessage.ReceiverEmail));
            }
            return emailSentResult;
        }

        public async Task<EmailSentResult> SendEmailMessageBySendGridAsync(EmailMessage emailMessage, string userId)
        {
            SendGridConfiguration sendGridConfiguration = GetSendGridConfiguration();
            EmailSentResult emailSentResult = new EmailSentResult() { Success = false };
            try
            {
                var apiKey = sendGridConfiguration.ApiKey;
                var client = new SendGridClient(apiKey);

                var sendGridMessage = new SendGridMessage()
                {
                    From = new EmailAddress(sendGridConfiguration.FromEmailAddress, sendGridConfiguration.DisplayName),
                    Subject = emailMessage.Subject,
                    //PlainTextContent = string.Empty,
                    HtmlContent = emailMessage.Body
                };

                sendGridMessage.AddTo(new EmailAddress(emailMessage.ReceiverEmail, emailMessage.ReceiverName));
                var response = await client.SendEmailAsync(sendGridMessage);

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    emailSentResult.Success = true;
                    emailSentResult.Id = userId;
                    log.Info("EmailSenderManager - SendEmailMessageBySendGridAsync - StatusCode: " + response.StatusCode + " - Email send successfully by SendGrid for user id: " + userId + " email: " + emailMessage.ReceiverEmail);
                }
                
            }
            catch (Exception ex)
            {
                emailSentResult.Ex = ex;
                log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "SendEmailMessageBySendGridAsync", emailMessage.ReceiverEmail));
            }
            return emailSentResult;
        }

        public async Task<EmailSentResult> SendEmailMessageBySendGridAsync(List<EmailMessage> emailMessageList, string userId)
        {
            SendGridConfiguration sendGridConfiguration = GetSendGridConfiguration();
            EmailSentResult emailSentResult = new EmailSentResult() { Success = false };
            var emailMessage = emailMessageList.FirstOrDefault();
            string receiverEmailList = String.Join(", ", emailMessageList);
            try
            {
                var apiKey = sendGridConfiguration.ApiKey;
                var client = new SendGridClient(apiKey);

                var sendGridMessage = new SendGridMessage()
                {
                    From = new EmailAddress(sendGridConfiguration.FromEmailAddress, sendGridConfiguration.DisplayName),
                    Subject = emailMessage.Subject,
                    //PlainTextContent = string.Empty,
                    HtmlContent = emailMessage.Body
                };

                foreach (var item in emailMessageList)
                {
                    sendGridMessage.AddTo(new EmailAddress(item.ReceiverEmail, item.ReceiverName));
                }
                
                var response = await client.SendEmailAsync(sendGridMessage);

                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    emailSentResult.Success = true;
                    emailSentResult.Id = userId;
                    log.Info("EmailSenderManager - SendEmailMessageBySendGridAsync - StatusCode: " + response.StatusCode + " - Email send successfully by SendGrid for user id: " + userId + " email list: " + receiverEmailList);
                }

            }
            catch (Exception ex)
            {
                emailSentResult.Ex = ex;
                log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "SendEmailMessageBySendGridAsync", receiverEmailList));
            }
            return emailSentResult;
        }
    }
}
