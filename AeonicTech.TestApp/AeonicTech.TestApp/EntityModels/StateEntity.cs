using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.EntityModels
{
    public partial class StateEntity
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateShortName { get; set; }
        public string CategoryName { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
