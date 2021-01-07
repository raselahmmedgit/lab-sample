using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class AppEmailConfig
    {
        public string FromEmailAddress { get; set; }
        public string FromEmailAddressDisplayName { get; set; }
        public string HostKey { get; set; }
        public string PortKey { get; set; }
        public string SslKey { get; set; }

        public string SendGridFromEmailAddress { get; set; }
        public string SendGridFromEmailAddressDisplayName { get; set; }
        public string SendGridApiKey { get; set; }
    }
}
