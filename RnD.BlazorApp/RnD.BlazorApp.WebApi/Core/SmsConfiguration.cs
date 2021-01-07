using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class SmsConfiguration
    {
        public string Number { get; set; }
        public string AuthToken { get; set; }
        public string Sid { get; set; }
    }
}
