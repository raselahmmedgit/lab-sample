using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProfile.App.EntityModels.Type
{
    [Table("AddressType")]
    public class AddressType
    {
        [Key]
        public int TypeId { get; set; }
        [StringLength(120)]
        public string TypeName { get; set; }
    }
}
