using TaskManagiment_Core.Common;

namespace TaskManagiment_DataAccess.Model
{
    public class TaskAssignment: BaseEntity, IAuditedEntity
    {
        public Guid TaskId { get; set; } 
        public Task Task { get; set; } = null!;
        public Guid UserId { get; set; } 
        public User User { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
