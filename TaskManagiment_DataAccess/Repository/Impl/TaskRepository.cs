using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess.Repository.Impl;
public class TaskRepository : BaseRepository<Tasks>, ITaskRepository
{
    private readonly DataBaseContext _dataBaseContext;
    public TaskRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
}
