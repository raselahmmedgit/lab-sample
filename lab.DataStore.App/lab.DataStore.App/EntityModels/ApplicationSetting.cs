using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.EntityModels
{
    [Table("ApplicationSetting")]
    public class ApplicationSetting : BaseEntityModel
    {
        [Display(Name = "Application Name")]
        [StringLength(250)]
        public string ApplicationName { get; set; }

        [Display(Name = "Version Name")]
        [StringLength(50)]
        public string VersionNumber { get; set; }

        [Display(Name = "Host Address")]
        [StringLength(50)]
        public string HostAddress { get; set; }
    }
}
