using TaskManagiment_Application.Model;
using TaskManagiment_DataAccess.Persistence;

namespace TaskManagiment_DataAccess.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public UserRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}
