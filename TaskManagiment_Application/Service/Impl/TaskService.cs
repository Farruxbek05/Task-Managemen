using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Repository;

namespace TaskManagiment_Application.Service.Impl;
public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskrepository;

    public TaskService(ITaskRepository
        taskRepository,
        IMapper mapper)
    {
        _taskrepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<Project>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _taskrepository.GetAllAsync();

        var mapper = _mapper.Map<List<Project>>(result);
        return mapper;
    }

    public async Task<Project> CreateAsync(CreateTasks createTodoItemModel, CancellationToken cancellationToken = default)
    {

        var todoItem = _mapper.Map<Project>(createTodoItemModel);
        var result = await _taskrepository.AddAsync(todoItem);

        if (result == null) return null;

        return new Project
        {
            Status = result.Status,
            Id = result.Id,
            Description = result.Description,
            Title = result.Title,
            DueDate = result.DueDate,
            ProjectId = result.ProjectId    

        };
    }

    async Task<IEnumerable<Project>> ITaskService.GetAllByListIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var todoItems = await _taskrepository.GetAllAsync(ti => ti.Id == id);


        return (IEnumerable<Project>)_mapper.Map<Project   >(todoItems);
    }

    public async Task<Project> UpdateAsync(Guid id, CreateTasks updateTodoItemModel, CancellationToken cancellationToken = default)
    {
        var todoItem = await _taskrepository.GetFirstAsync(ti => ti.Id == id);

        _mapper.Map(updateTodoItemModel, todoItem);

        return new Project
        {
            Id = (await _taskrepository.UpdateAsync(todoItem)).Id
        };
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _taskrepository.GetFirstAsync(u => u.Id == id);

        if (user == null)
            return false;

        await _taskrepository.DeleteAsync(user);
        return true;
    }
}



