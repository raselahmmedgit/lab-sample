using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.EntityModels
{
    public partial class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryDisplayName { get; set; }
        public string CountryIso { get; set; }
        public string CountryIso3 { get; set; }
        public string NumberCode { get; set; }
        public string PhoneCode { get; set; }
        public bool IsActive { get; set; }
    }
}
