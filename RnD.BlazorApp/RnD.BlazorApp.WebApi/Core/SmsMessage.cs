using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class SmsMessage
    {
        public string ReceiverPhoneNo { get; set; }
        public string ReceiverPhoneCode { get; set; }
        public string ReceiverEmailAddress { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
