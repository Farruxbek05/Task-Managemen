using Microsoft.AspNetCore.Mvc;
using TaskManagiment_Application.Service.Impl;
using TaskManagiment_Application;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_Application.Service;

namespace TaskManagement_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _NotificationService;

        public NotificationController(NotificationService notificationService)
        {
            _NotificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<Notification>>>> GetAll()
        {
            var result = await _NotificationService.GetAllAsync();
            var response = ApiResult<List<Notification>>.Success(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateNotification createUserModel)
        {
            var result = await _NotificationService.CreateAsync(createUserModel);

            if (result == null) return BadRequest(ApiResult<Notification>.Failure());

            return Ok(ApiResult<Notification>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CreateNotification updateUserModel)
        {
            return Ok(ApiResult<Notification>.Success(
                await _NotificationService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _NotificationService.DeleteAsync(id)));
        }
    }
}
