using System;
using System.Collections.Generic;
using System.Text;

namespace lab.DataStore.App.EmailSender
{
    public class SendGridConfiguration
    {
        public string FromEmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string ApiKey { get; set; }
    }
}
