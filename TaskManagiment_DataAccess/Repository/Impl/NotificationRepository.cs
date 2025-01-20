using TaskManagiment_Application.Model;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess.Repository.Impl;
public class NotificationRepository : BaseRepository<Notification>, INotificationReposioty
{
    private readonly DataBaseContext _dataBaseContext;
    public NotificationRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
}
