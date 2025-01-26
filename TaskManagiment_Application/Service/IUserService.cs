using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User> AddUserAsync(CreateUser userForCreationDto);
        Task<User> UpdateUserAsync(Guid id, CreateUser userDto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> VerifyPassword(User user, string password);
    }
}
