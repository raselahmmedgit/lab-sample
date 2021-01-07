using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RnD.BlazorApp.WebApi.Core;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace RnD.BlazorApp.WebApi.Manager
{
    public class SmsSenderManager
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(SmsSenderManager));
        private static IConfiguration _configuration;
        private static SmsConfiguration _smsConfiguration;
        private static ContactUsConfiguration _contactUsConfiguration;

        public SmsSenderManager()
        {
        }

        public SmsSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _smsConfiguration = new SmsConfiguration();
            _smsConfiguration.Number = _configuration["AppSmsConfig:TwilioFromNumber"].ToString();
            _smsConfiguration.Sid = _configuration["AppSmsConfig:TwilioAccountSid"].ToString();
            _smsConfiguration.AuthToken = _configuration["AppSmsConfig:TwilioAuthToken"].ToString();
            _log.Debug("SmsSenderManager - Number: " + _smsConfiguration.Number);

            _contactUsConfiguration = new ContactUsConfiguration();
            _contactUsConfiguration.EmailAddress = _configuration["AppContactUsConfig:EmailAddress"].ToString();
            _contactUsConfiguration.EmailAddressDisplayName = _configuration["AppContactUsConfig:EmailAddressDisplayName"].ToString();
            _contactUsConfiguration.PhoneNumber = _configuration["AppContactUsConfig:PhoneNumber"].ToString();
            _contactUsConfiguration.PhoneNumberDisplayName = _configuration["AppContactUsConfig:PhoneNumberDisplayName"].ToString();
            _log.Debug("SmsSenderManager - ContactUsConfiguration - EmailAddress: " + _contactUsConfiguration.EmailAddress);
            _log.Debug("SmsSenderManager - ContactUsConfiguration - PhoneNumber: " + _contactUsConfiguration.PhoneNumber);
        }

        public SmsConfiguration GetSmsConfiguration()
        {
            if (_smsConfiguration != null)
            {
                return _smsConfiguration;
            }
            else
            {
                return null;
            }
        }

        public ContactUsConfiguration GetContactUsConfiguration()
        {
            if (_contactUsConfiguration != null)
            {
                return _contactUsConfiguration;
            }
            else
            {
                return null;
            }
        }

        public SmsSentResult SendSmsMessage(SmsMessage smsMessage, string userId)
        {
            SmsConfiguration smsConfiguration = GetSmsConfiguration();
            SmsSentResult smsSentResult = new SmsSentResult() { Success = false };
            try
            {
                TwilioClient.Init(smsConfiguration.Sid, smsConfiguration.AuthToken);

                var message = MessageResource.Create(
                    body: smsMessage.Body,
                    from: new Twilio.Types.PhoneNumber(smsConfiguration.Number),
                    to: new Twilio.Types.PhoneNumber(smsMessage.ReceiverPhoneNo)
                );
                smsSentResult.Success = true;
                smsSentResult.Id = userId;

                _log.Info("SmsSenderManager - SendSmsMessage - Sms send successfully for user id: " + userId + " number: " + smsMessage.ReceiverPhoneNo);
            }
            catch (Exception ex)
            {
                smsSentResult.Ex = ex;
                _log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "SendSmsMessage", smsMessage.ReceiverPhoneNo));
            }
            return smsSentResult;
        }
    }
}
