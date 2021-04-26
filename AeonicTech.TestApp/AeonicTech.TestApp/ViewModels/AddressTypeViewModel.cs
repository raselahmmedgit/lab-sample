using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.ViewModels
{
    public partial class AddressTypeViewModel : BaseViewModel
    {
        public int TypeId { get; set; }

        [DisplayName("Address Type")]
        public string TypeName { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
