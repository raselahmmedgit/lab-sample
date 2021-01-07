using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.BlazorApp.WebApi.Core
{
    public class ContactUsConfiguration
    {
        public string EmailAddress { get; set; }
        public string EmailAddressDisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberDisplayName { get; set; }
    }
}
