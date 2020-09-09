using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProfile.App.EntityModels.Base
{
    [Table("BaseCountry")]
    public class BaseCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryDisplayName { get; set; }
        public string CountryIso { get; set; }
        public string CountryIso3 { get; set; }
        public string NumberCode { get; set; }
        public string PhoneCode { get; set; }
        public bool IsPublished { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
