using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.ViewModels
{
    public class StateEntityViewModel
    {
        public int StateId { get; set; }
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        public string StateShortName { get; set; }
        public string CategoryName { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
