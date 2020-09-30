using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.DataStore.App.EntityModels
{
    [Table("ContactProfile")]
    public class ContactProfile : BaseEntityModel, IChangeTrackerEntity, IDeleteTrackerEntity
    {
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string PreferredName { get; set; }
        public Guid? AddressId { get; set; }
        public string PrimaryPassword { get; set; }
        public bool IsDeactivated { get; set; }
        public Guid? ProfilePictureId { get; set; }
        public bool EmailAllowed { get; set; }
        public bool SmsAllowed { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int GenderTypeId { get; set; }
        public bool IsArchived { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy  { get; set; }
        public DateTime? UpdatedDate  { get; set; }
        public string UpdatedBy  { get; set; }
        public bool IsDeleted  { get; set; }
        public string DeletedBy  { get; set; }
        public DateTime? DeletedDate  { get; set; }
    }
}
