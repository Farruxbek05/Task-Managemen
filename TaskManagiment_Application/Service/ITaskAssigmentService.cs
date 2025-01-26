using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service
{
    public interface ITaskAssigmentService
    {
        Task<List<TaskAssignment>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TaskAssignment> CreateAsync(CreateTaskAssignment createTodoItemModel,
        CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskAssignment>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TaskAssignment> UpdateAsync(Guid id, CreateTaskAssignment updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
