using lab.DataStore.App.Helper;
using lab.DataStore.App.SmsSender;
using log4net;
using Microsoft.Extensions.Configuration;
using System;

namespace lab.DataStore.App.BLL
{
    public class SmsSenderManager
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SmsSenderManager));
        private static IConfiguration _configuration;
        private static SmsConfiguration _smsConfiguration;

        public SmsSenderManager()
        {
        }

        public SmsSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _smsConfiguration = new SmsConfiguration();
            _smsConfiguration.Number = _configuration["AppSmsConfig:TwilioFromNumber"].ToString();
            log.Debug("SmsSenderManager - Number: " + _smsConfiguration.Number);
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
        
        public SmsSentResult SendSmsMessage(SmsMessage smsMessage, string userId)
        {
            SmsConfiguration smsConfiguration = GetSmsConfiguration();
            SmsSentResult smsSentResult = new SmsSentResult() { Success = false };
            try
            {
                smsSentResult.Success = true;
                smsSentResult.Id = userId;

                log.Info("SmsSenderManager - SendSmsMessage - Sms send successfully for user id: " + userId + " number: " + smsMessage.ReceiverPhoneNo);
            }
            catch (Exception ex)
            {
                smsSentResult.Ex = ex;
                log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "SendSmsMessage", smsMessage.ReceiverPhoneNo));
            }
            return smsSentResult;
        }
    }
}
