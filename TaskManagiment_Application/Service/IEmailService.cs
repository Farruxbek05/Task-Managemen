using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Service
{
    public interface IEmailService
    {
        Task<ApiResult> SendEmailAsync(User user);
    }
}
