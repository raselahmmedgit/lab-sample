using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.ViewModels
{
    public partial class CompanyProfileViewModel
    {
        public int CompanyId { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
