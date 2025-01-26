using Microsoft.AspNetCore.Mvc;
using TaskManagiment_Application.Service.Impl;
using TaskManagiment_Application;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagement_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<Project>>>> GetAll()
        {
            var result = await _taskService.GetAllAsync();
            var response = ApiResult<List<Project>>.Success(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTasks createUserModel)
        {
            var result = await _taskService.CreateAsync(createUserModel);

            if (result == null) return BadRequest(ApiResult<Project>.Failure());

            return Ok(ApiResult<Project>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CreateTasks updateUserModel)
        {
            return Ok(ApiResult<Project>.Success(
                await _taskService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _taskService.DeleteAsync(id)));
        }
    }
}