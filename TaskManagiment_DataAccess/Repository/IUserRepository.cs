using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_DataAccess.Repository
{
    public interface IUserRepository : IBaseRepository<User> 
    {
        Task<User?> GetUserByEmailAsync(string email);
    }

}


