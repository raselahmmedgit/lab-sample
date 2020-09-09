using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProfile.App.EntityModels
{
    [Table("BasePicture")]
    public class BasePicture
    {
        [Key]
        public Guid PictureId { get; set; }
        public int PictureTypeId { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
        public string VirtualPath { get; set; }
        public bool IsNew { get; set; }
        public bool? IsTemporaryPicture { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
