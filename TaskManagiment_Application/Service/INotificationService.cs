using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Notification> CreateAsync(CreateNotification createTodoItemModel,
        CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Notification>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Notification> UpdateAsync(Guid id, CreateNotification updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
