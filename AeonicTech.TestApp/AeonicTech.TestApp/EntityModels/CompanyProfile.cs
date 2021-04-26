using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.EntityModels
{
    public partial class CompanyProfile
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public bool IsActive { get; set; }
    }
}
