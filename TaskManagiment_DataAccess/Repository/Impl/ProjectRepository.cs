using TaskManagiment_Application.Model;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess.Repository.Impl;

public class ProjectRepository : BaseRepository<Project>, IProjectReposioty
{
    private readonly DataBaseContext _dataBaseContext;
    public ProjectRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
}
