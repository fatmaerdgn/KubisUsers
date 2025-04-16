using Microsoft.AspNetCore.Mvc;
using KubisUserDeneme.Service.Services;

namespace KubisUserDeneme.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string name, CancellationToken cancellationToken)
        {
            var result = await _roleService.CreateRoleAsync(name);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
    }
}