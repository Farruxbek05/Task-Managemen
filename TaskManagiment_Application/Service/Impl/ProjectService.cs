using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Repository;

namespace TaskManagiment_Application.Service.Impl
{
    public class ProjectService : IProjectservice
    {
        private readonly IMapper _mapper;
        private readonly IProjectReposioty _projectrepository;

        public ProjectService(IProjectReposioty
            projectRepository,
            IMapper mapper)
        {
            _projectrepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<Project>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _projectrepository.GetAllAsync();

            var mapper = _mapper.Map<List<Project>>(result);
            return mapper;
        }

        public async Task<Project> CreateAsync(CreateProject createTodoItemModel, CancellationToken cancellationToken = default)
        {

            var todoItem = _mapper.Map<Project>(createTodoItemModel);
            var result = await _projectrepository.AddAsync(todoItem);

            if (result == null) return null;

            return new Project
            {
                Id = result.Id,
                Name = result.Name,
                Tasks = result.Tasks,
            
            };
        }

        public async Task<IEnumerable<Project>> GetAllByListIdAsync(Guid id, CancellationToken? cancellationToken)
        {
            var todoItems = await _projectrepository.GetAllAsync(ti => ti.Id == id);


            return (IEnumerable<Project>)_mapper.Map<Project>(todoItems);
        }

        public async Task<Project> UpdateAsync(Guid id, CreateProject updateTodoItemModel, CancellationToken cancellationToken = default)
        {
            var todoItem = await _projectrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new Project
            {
                Id = (await _projectrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _projectrepository.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _projectrepository.DeleteAsync(user);
            return true;
        }
    }
}
