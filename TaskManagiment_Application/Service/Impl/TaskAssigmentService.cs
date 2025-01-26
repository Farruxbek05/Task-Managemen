using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Repository;

namespace TaskManagiment_Application.Service.Impl
{
    public class TaskAssigmentService : ITaskAssigmentService
    {
        private readonly ITaskAssignmentRep _taskAssignmentRep;
        private readonly IMapper _mapper;
        public TaskAssigmentService(ITaskAssignmentRep taskAssignmentRep, IMapper mapper)
        {
            _taskAssignmentRep = taskAssignmentRep;
            _mapper = mapper;
        }

        public async Task<List<TaskAssignment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _taskAssignmentRep.GetAllAsync();

            var mapper = _mapper.Map<List<TaskAssignment>>(result);
            return mapper;
        }

        public async Task<TaskAssignment> CreateAsync(CreateTaskAssignment createTodoItemModel, CancellationToken cancellationToken = default)
        {

            var todoItem = _mapper.Map<TaskAssignment>(createTodoItemModel);
            var result = await _taskAssignmentRep.AddAsync(todoItem);

            if (result == null) return null;

            return new TaskAssignment
            {
                Id = result.Id,
                TaskId = result.TaskId,
                UserId = result.UserId,
            };
        }

        public async Task<TaskAssignment> UpdateAsync(Guid id, CreateTaskAssignment updateTodoItemModel, CancellationToken cancellationToken = default)
        {
            var todoItem = await _taskAssignmentRep.GetFirstAsync(ti => ti.Id == id);
            _mapper.Map(updateTodoItemModel, todoItem);

            return new TaskAssignment
            {
                Id = (await _taskAssignmentRep.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _taskAssignmentRep.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _taskAssignmentRep.DeleteAsync(user);
            return true;
        }

        public async Task<IEnumerable<TaskAssignment>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItems = await _taskAssignmentRep.GetAllAsync(ti => ti.Id == id);


            return (IEnumerable<TaskAssignment>)_mapper.Map<TaskAssignment>(todoItems);
        }
    }

}

