using TaskManagiment_Core.Enum;

namespace TaskManagiment_Core.DTO;
public class CreateTasks
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DueDate { get; set; }
    public TaskStatuss Status { get; set; } = TaskStatuss.Todo;
    public Guid ProjectId { get; set; }
}
