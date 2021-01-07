using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class SendGridConfiguration
    {
        public string FromEmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string ApiKey { get; set; }
    }
}
