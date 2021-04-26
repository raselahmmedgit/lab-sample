using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.ViewModels
{
    public partial class AddressEntityViewModel : BaseViewModel
    {
        public int AddressId { get; set; }

        [Display(Name = "Address Type")]
        public int? AddressTypeId { get; set; }

        [Required]
        [StringLength(250)]
        [EmailAddress]
        [Display(Name = "Email")]
        //Source: https://www.w3.org/TR/2012/WD-html-markup-20120320/input.email.html#input.email.attrs.value.single
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
        public string EmailAddress { get; set; }

        [Display(Name = "Address Line One")]
        public string AddressLineOne { get; set; }

        [Display(Name = "Address Line Two")]
        public string AddressLineTwo { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Display(Name = "State Name")]
        public int? StateId { get; set; }

        public int? CountryId { get; set; }

        [Display(Name = "Website")]
        public string WebsiteAddress { get; set; }

        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }

        [Display(Name = "Office Phone Code")]
        public string OfficePhoneCode { get; set; }

        [Display(Name = "Office Phone Country Id")]
        public int? OfficePhoneCountryId { get; set; }

        [Display(Name = "Primary Phone")]
        public string PrimaryPhone { get; set; }

        [Display(Name = "Primary Phone Code")]
        public string PrimaryPhoneCode { get; set; }

        [Display(Name = "Primary Phone Country Id")]
        public int? PrimaryPhoneCountryId { get; set; }

        [Display(Name = "Other Phone")]
        public string OtherPhone { get; set; }

        [Display(Name = "Other Phone Code")]
        public string OtherPhoneCode { get; set; }

        [Display(Name = "Other Phone Country Id")]
        public int? OtherPhoneCountryId { get; set; }

        [Display(Name = "Primary")]
        public bool IsPrimary { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        public virtual AddressTypeViewModel AddressTypeViewModel { get; set; }
    }
}
