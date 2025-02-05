﻿using TaskManagiment_Core.Common;
using TaskManagiment_Core.Enum;

namespace TaskManagiment_DataAccess.Model
{

    public class Tasks : BaseEntity, IAuditedEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskStatuss Status { get; set; } = TaskStatuss.Todo;
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
