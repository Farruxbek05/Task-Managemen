using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service;
public interface ITaskService
{
    Task<List<Tasks>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Tasks> CreateAsync(CreateTasks createTodoItemModel,
    CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Tasks>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Tasks> UpdateAsync(Guid id, CreateTasks updateTodoItemModel,
        CancellationToken cancellationToken = default);
}
