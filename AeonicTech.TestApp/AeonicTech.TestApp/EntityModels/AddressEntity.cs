using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.EntityModels
{
    public partial class AddressEntity : BaseEntityModel
    {
        [Key]
        public int AddressId { get; set; }
        public int? AddressTypeId { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string WebsiteAddress { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePhoneCode { get; set; }
        public int? OfficePhoneCountryId { get; set; }
        public string PrimaryPhone { get; set; }
        public string PrimaryPhoneCode { get; set; }
        public int? PrimaryPhoneCountryId { get; set; }
        public string OtherPhone { get; set; }
        public string OtherPhoneCode { get; set; }
        public int? OtherPhoneCountryId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public virtual AddressType AddressType { get; set; }
    }
}
