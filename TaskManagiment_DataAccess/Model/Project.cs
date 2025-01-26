using TaskManagiment_Core.Common;

namespace TaskManagiment_DataAccess.Model
{
    public class Project: BaseEntity,IAuditedEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Task> Task { get; set; } = new List<Task>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
