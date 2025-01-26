namespace TaskManagiment_Core.DTO;
public class CreateNotification
{
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public bool IsRead { get; set; } = false;
}
