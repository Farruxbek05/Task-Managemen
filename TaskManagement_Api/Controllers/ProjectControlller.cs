using Microsoft.AspNetCore.Mvc;
using TaskManagiment_Application;
using TaskManagiment_Application.Service.Impl;
using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Model;

namespace TaskManagement_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult<List<Project>>>> GetAll()
        {
            var result = await _projectService.GetAllAsync();
            var response = ApiResult<List<Project>>.Success(result);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProject createUserModel)
        {
            var result = await _projectService.CreateAsync(createUserModel);

            if (result == null) return BadRequest(ApiResult<Project>.Failure());

            return Ok(ApiResult<Project>.Success(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, CreateProject updateUserModel)
        {
            return Ok(ApiResult<Project>.Success(
                await _projectService.UpdateAsync(id, updateUserModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<bool>.Success(await _projectService.DeleteAsync(id)));
        }
    }
}