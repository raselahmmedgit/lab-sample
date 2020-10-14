using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.EntityModels.Type
{
    [Table("PictureType")]
    public class PictureType
    {
        [Key]
        public int TypeId { get; set; }

        [Display(Name = "Type Name")]
        [StringLength(120)]
        public string TypeName { get; set; }
    }
}
