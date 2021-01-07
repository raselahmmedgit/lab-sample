using RnD.BlazorApp.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public static class SmsTemplateHelper
    {
        public static string GetContactSendMessageSmsTemplate(string title = "Contact Us!", ContactSendMessageViewModel contactSendMessageViewModel = null)
        {
            string template = $"{title} - Subject: {contactSendMessageViewModel.ContactSubject} , Message: {contactSendMessageViewModel.ContactMessage}";
            return template;
        }
    }
}
