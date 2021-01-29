using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGlassCompany.WebSite.Core
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
