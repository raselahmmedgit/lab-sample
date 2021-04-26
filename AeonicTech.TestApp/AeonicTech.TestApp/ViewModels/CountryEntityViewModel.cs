using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.ViewModels
{
    public class CountryEntityViewModel
    {
        public int CountryId { get; set; }
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        public string CountryDisplayName { get; set; }
        public string CountryIso { get; set; }
        public string CountryIso3 { get; set; }
        public string NumberCode { get; set; }
        public string PhoneCode { get; set; }
        public bool IsActive { get; set; }
    }
}
