using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service;
public interface ITaskService
{
    Task<List<Project>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Project> CreateAsync(CreateTasks createTodoItemModel,
    CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Project>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Project> UpdateAsync(Guid id, CreateTasks updateTodoItemModel,
        CancellationToken cancellationToken = default);
}
