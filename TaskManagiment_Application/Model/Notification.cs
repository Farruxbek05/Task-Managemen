using TaskManagiment_Core.Common;

namespace TaskManagiment_Application.Model
{
    public class Notification:BaseEntity, IAuditedEntity
    {
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; } 
        public User User { get; set; } = null!;
        public bool IsRead { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
