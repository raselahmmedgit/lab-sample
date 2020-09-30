using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Core
{
    public class AppEmailConfig
    {
        public string UserNameKey { get; set; }
        public string PasswordKey { get; set; }
        public string HostKey { get; set; }
        public string PortKey { get; set; }
        public string SslKey { get; set; }
    }
}
