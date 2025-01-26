using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess.Repository.Impl;
public class TaskAssignmentRep : BaseRepository<TaskAssignment>, ITaskAssignmentRep
{
    private readonly DataBaseContext _dataBaseContext;
    public TaskAssignmentRep(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
}

