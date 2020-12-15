using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.ViewModels
{
    public class ContactProfileViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string PreferredName { get; set; }
        [StringLength(500)]
        public string ContactProfileFullName => string.IsNullOrEmpty(PreferredName) ? (FirstName + " " + LastName)?.Trim() : PreferredName;
        public Guid? AddressId { get; set; }
        public string PrimaryPassword { get; set; }
        public bool IsDeactivated { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public bool EmailAllowed { get; set; }
        public bool SmsAllowed { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public int GenderTypeId { get; set; }
        public bool IsArchived { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
