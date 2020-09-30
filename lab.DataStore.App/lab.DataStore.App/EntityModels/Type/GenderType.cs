using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.EntityModels.Type
{
    [Table("GenderType")]
    public class GenderType
    {
        [Key]
        public int TypeId { get; set; }
        [StringLength(120)]
        public string TypeName { get; set; }
    }
}
