using CityGlassCompany.WebSite.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using CityGlassCompany.WebSite.ViewModels;
using System.Text;
using static CityGlassCompany.WebSite.Core.AppEnums;

namespace CityGlassCompany.WebSite.Managers
{
    public class EmailSenderManager:IEmailSenderManager
    {
        private readonly CityGlassEmailConfig _cityGlassEmailConfig;
        private readonly CityGlassContactUsConfig _cityGlassContactUsConfig;

        public EmailSenderManager(IOptions<CityGlassEmailConfig> cityGlassEmailConfig, IOptions<CityGlassContactUsConfig> cityGlassContactUsConfig)
        {
            _cityGlassEmailConfig = cityGlassEmailConfig.Value;
            _cityGlassContactUsConfig = cityGlassContactUsConfig.Value;
        }

        public async Task<EmailSentResult> ContactSendEmailToAdmin(ContactSendMessageViewModel contactSendMessageViewModel)
        {
            try
            {

                string emailTitle = $"City Glass - Contact Us!";
                string emailSubject = emailTitle;
                string emailTemplate = EmailTemplateHelper.GetContactSendMessageEmailTemplate(emailTitle, contactSendMessageViewModel: contactSendMessageViewModel);

                string emailAddressDisplayName = _cityGlassContactUsConfig.EmailAddressDisplayName;
                string emailAddress = _cityGlassContactUsConfig.EmailAddress;

                if (contactSendMessageViewModel.MessageCategoryValue == MessageCategoryValueEnum.CommercialGlassWindowsAndDoors.ToString()) {
                    emailAddress = _cityGlassContactUsConfig.CommercialGlassWindowsAndDoors;
                }
                else if (contactSendMessageViewModel.MessageCategoryValue == MessageCategoryValueEnum.LargeScaleGlassAndMirrorBids.ToString())
                {
                    emailAddress = _cityGlassContactUsConfig.LargeScaleGlassAndMirrorBids;
                }
                else if (contactSendMessageViewModel.MessageCategoryValue == MessageCategoryValueEnum.MirrorShowerGlassInstallation.ToString())
                {
                    emailAddress = _cityGlassContactUsConfig.MirrorShowerGlassInstallation;
                }
                else if (contactSendMessageViewModel.MessageCategoryValue == MessageCategoryValueEnum.ResidentialGlassWindowsAndDoors.ToString())
                {
                    emailAddress = _cityGlassContactUsConfig.ResidentialGlassWindowsAndDoors;
                }
                else if (contactSendMessageViewModel.MessageCategoryValue == MessageCategoryValueEnum.TheOnlineEstimates.ToString())
                {
                    emailAddress = _cityGlassContactUsConfig.TheOnlineEstimates;
                }

                EmailMessage emailMessage = new EmailMessage();
                emailMessage.ReceiverName = emailAddressDisplayName;
                emailMessage.ReceiverEmail = emailAddress;
                emailMessage.Subject = emailSubject;
                emailMessage.IsHtml = true;
                emailMessage.Body = emailTemplate;

                var emailSentResult = await SendEmailMessage(emailMessage, "contactUsUser");

                if (!string.IsNullOrEmpty(_cityGlassEmailConfig.TestEmailAddress))
                {
                    string[] testEmailAddressList = _cityGlassEmailConfig.TestEmailAddress.Split(",");
                    foreach (var testEmailAddress in testEmailAddressList)
                    {
                        string[] testEmailAddressReceiverEmailAndNameList = testEmailAddress.Split("_");
                        EmailMessage testEmailMessage = new EmailMessage();
                        testEmailMessage.ReceiverName = testEmailAddressReceiverEmailAndNameList[0].ToString();
                        testEmailMessage.ReceiverEmail = testEmailAddressReceiverEmailAndNameList[1].ToString();
                        testEmailMessage.Subject = emailSubject;
                        testEmailMessage.IsHtml = true;
                        testEmailMessage.Body = emailTemplate;

                        var testEmailSentResult = await SendEmailMessage(testEmailMessage, "contactUsUser");
                    }
                }

                return emailSentResult;
            }
            catch (Exception ex)
            {
                return new EmailSentResult { Success = false, Ex = ex };
            }
        }
        public async Task<EmailSentResult> SendEmailMessage(EmailMessage emailMessage, string userId)
        {

            EmailSentResult emailSentResult = new EmailSentResult() { Success = false };
            try
            {
                var smtp = new SmtpClient
                {
                    Host = _cityGlassEmailConfig.Host,
                    Port = Convert.ToInt32(_cityGlassEmailConfig.Port),
                    EnableSsl = Convert.ToBoolean(_cityGlassEmailConfig.Ssl),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_cityGlassEmailConfig.FromEmailAddress, _cityGlassEmailConfig.Password)
                };
                using (var smtpMessage = new MailMessage(new MailAddress(_cityGlassEmailConfig.FromEmailAddress, _cityGlassEmailConfig.FromEmailAddressDisplayName)
                    , new MailAddress(emailMessage.ReceiverEmail, emailMessage.ReceiverName)))
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

                    smtp.Dispose();
                }
            }
            catch (Exception ex)
            {
                emailSentResult.Ex = ex;
            }
            await Task.FromResult(0);
            return emailSentResult;
        }
    }

    public interface IEmailSenderManager
    {
        Task<EmailSentResult> ContactSendEmailToAdmin(ContactSendMessageViewModel contactSendMessageViewModel);
        Task<EmailSentResult> SendEmailMessage(EmailMessage emailMessage, string userId);
    }
}
