using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class EmailConfiguration
    {
        public string FromEmailAddress { get; set; }
        public string FromEmailAddressDisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string TestEmailAddress { get; set; }
    }
}
