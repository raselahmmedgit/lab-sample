using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProfile.App.EntityModels
{
    [Table("ApplicationSetting")]
    public class ApplicationSetting : BaseEntityModel
    {
        [StringLength(250)]
        public string ApplicationName { get; set; }

        [StringLength(50)]
        public string VersionNumber { get; set; }

        [StringLength(50)]
        public string HostAddress { get; set; }
    }
}
