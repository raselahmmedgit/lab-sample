using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab.ContactProfile.App.EntityModels.Base
{
    [Table("BaseState")]
    public class BaseState
    {
        [Key]
        public int StateId { get; set; }
        [StringLength(250)]
        public string StateName { get; set; }
        [StringLength(120)]
        public string StateShortName { get; set; }
        [StringLength(120)]
        public string CategoryName { get; set; }
        public int CountryId { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
