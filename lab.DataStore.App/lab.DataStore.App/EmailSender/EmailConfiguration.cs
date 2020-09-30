using System;
using System.Collections.Generic;
using System.Text;

namespace lab.DataStore.App.EmailSender
{
    public class EmailConfiguration
    {
        public string FromEmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string MailToTestEmail { get; set; }
    }
}
