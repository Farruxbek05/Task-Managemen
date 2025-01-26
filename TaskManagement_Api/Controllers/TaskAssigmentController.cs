using Microsoft.AspNetCore.Mvc;
using TaskManagiment_Application.Service.Impl;
using TaskManagiment_Application;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagement_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskAssigmentController : ControllerBase
    {
        private readonly TaskAssigmentService _taskassigmentService;

        public TaskAssigmentController(TaskAssigmentService taskassigmenttService)
        {
            _taskassigmentService = taskassigmenttService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<TaskAssignment>>>> GetAll()
        {
            var result = await _taskassigmentService.GetAllAsync();
            var response = ApiResult<List<TaskAssignment>>.Success(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateTaskAssignment createUserModel)
        {
            var result = await _taskassigmentService.CreateAsync(createUserModel);

            if (result == null) return BadRequest(ApiResult<TaskAssignment>.Failure());

            return Ok(ApiResult<TaskAssignment>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CreateTaskAssignment updateUserModel)
        {
            return Ok(ApiResult<TaskAssignment>.Success(
                await _taskassigmentService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _taskassigmentService.DeleteAsync(id)));
        }
    }
}
