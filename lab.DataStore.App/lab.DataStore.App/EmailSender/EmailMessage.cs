using System;
using System.Collections.Generic;
using System.Text;

namespace lab.DataStore.App.EmailSender
{
    public class EmailMessage
    {
        public string ReceiverEmail { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }
}
