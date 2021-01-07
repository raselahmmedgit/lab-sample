using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.ViewModels
{
    public class ContactSendMessageViewModel
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
    }
}
