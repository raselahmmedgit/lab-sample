using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RnD.TestSample.Models
{
    public class Profile
    {
        public int Id { get; set; }
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "Name is required")]
        public string  Name { get; set; }
        [DisplayName("Email: ")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }

    }

    public class Address
    {
        public int Id { get; set; }
        [DisplayName("Address: ")]
        [Required(ErrorMessage = "Address is required")]
        public string Name { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }
        [DisplayName("Contact Number: ")]
        [Required(ErrorMessage = "Contact Number is required")]
        public string Number { get; set; }
    }
}