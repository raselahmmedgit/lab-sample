using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.EntityModels
{
    public partial class AddressType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
