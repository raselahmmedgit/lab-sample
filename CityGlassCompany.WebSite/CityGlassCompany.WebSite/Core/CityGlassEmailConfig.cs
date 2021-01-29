using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Core
{
    public class CityGlassEmailConfig
    {
        public string FromEmailAddress { get; set; }
        public string FromEmailAddressDisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Ssl { get; set; }

        public string SendGridFromEmailAddress { get; set; }
        public string SendGridFromEmailAddressDisplayName { get; set; }
        public string SendGridApiKey { get; set; }

        public string TestEmailAddress { get; set; }
    }
}
