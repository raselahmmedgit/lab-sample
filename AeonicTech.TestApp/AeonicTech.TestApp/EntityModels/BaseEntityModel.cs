using System;

namespace AeonicTech.TestApp.EntityModels
{
    public class BaseEntityModel
    {
        public int CompanyId { get; set; }
    }

    public interface IChangeTrackerEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }

    public class ChangeTrackerEntity : IChangeTrackerEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

    public interface IDeleteTrackerEntity
    {
        bool IsDeleted { get; set; }
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }

    public class DeleteTrackerEntity : IDeleteTrackerEntity
    {
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
