using AutoMapper;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Repository;

namespace TaskManagiment_Application.Service.Impl
{
    public class NotificationService:INotificationService
    {
        private readonly IMapper _mapper;
        private readonly INotificationReposioty _notificationrepository;

        public NotificationService(INotificationReposioty
            notificationRepository,
            IMapper mapper)
        {
            _notificationrepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<Notification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _notificationrepository.GetAllAsync();

            var mapper = _mapper.Map<List<Notification>>(result);
            return mapper;
        }

        public async Task<Notification> CreateAsync(CreateNotification createTodoItemModel, CancellationToken cancellationToken = default)
        {

            var todoItem = _mapper.Map<Notification>(createTodoItemModel);
            var result = await _notificationrepository.AddAsync(todoItem);

            if (result == null) return null;

            return new Notification
            {
                Id = result.Id,
                IsRead = result.IsRead,
                Message = result.Message,
                UserId = result.UserId


            };
        }

        public async Task<Notification> UpdateAsync(Guid id, CreateNotification updateTodoItemModel, CancellationToken cancellationToken = default)
        {
            var todoItem = await _notificationrepository.GetFirstAsync(ti => ti.Id == id);

            _mapper.Map(updateTodoItemModel, todoItem);

            return new Notification
            {
                Id = (await _notificationrepository.UpdateAsync(todoItem)).Id
            };
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _notificationrepository.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _notificationrepository.DeleteAsync(user);
            return true;
        }

        public async Task<IEnumerable<Notification>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var todoItems = await _notificationrepository.GetAllAsync(ti => ti.Id == id);


            return (IEnumerable<Notification>)_mapper.Map<Notification>(todoItems);
        }
    }
}

