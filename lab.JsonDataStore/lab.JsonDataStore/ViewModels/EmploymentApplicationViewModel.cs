using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.JsonDataStore.ViewModels
{
    public class EmploymentApplicationViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
