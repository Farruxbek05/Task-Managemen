using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service
{
    public interface IProjectservice
    {
        Task<List<Project>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Project> CreateAsync(CreateProject createTodoItemModel,
        CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Project>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Project> UpdateAsync(Guid id, CreateProject updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
