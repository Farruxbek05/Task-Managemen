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

    public async Task<List<Tasks>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _taskrepository.GetAllAsync();

        var mapper = _mapper.Map<List<Tasks>>(result);
        return mapper;
    }

    public async Task<Tasks> CreateAsync(CreateTasks createTodoItemModel, CancellationToken cancellationToken = default)
    {

        var todoItem = _mapper.Map<Tasks>(createTodoItemModel);
        var result = await _taskrepository.AddAsync(todoItem);

        if (result == null) return null;

        return new Tasks
        {
            Status = result.Status,
            Id = result.Id,
            Description = result.Description,
            Title = result.Title,
            DueDate = result.DueDate,
            ProjectId = result.ProjectId    

        };
    }

    async Task<IEnumerable<Tasks>> ITaskService.GetAllByListIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var todoItems = await _taskrepository.GetAllAsync(ti => ti.Id == id);


        return (IEnumerable<Tasks>)_mapper.Map<Tasks>(todoItems);
    }

    public async Task<Tasks> UpdateAsync(Guid id, CreateTasks updateTodoItemModel, CancellationToken cancellationToken = default)
    {
        var todoItem = await _taskrepository.GetFirstAsync(ti => ti.Id == id);

        _mapper.Map(updateTodoItemModel, todoItem);

        return new Tasks
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



