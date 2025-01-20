using TaskManagiment_Application.Enum;

namespace TaskManagiment_Application.DTO;
public class CreateTasks
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DueDate { get; set; }
    public TaskStatuss Status { get; set; } = TaskStatuss.Todo;
    public Guid ProjectId { get; set; }
}
