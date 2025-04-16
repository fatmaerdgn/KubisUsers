using Microsoft.AspNetCore.Mvc;
using KubisUserDeneme.Service.Services;

namespace KubisUserDeneme.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid userId, string roleName, CancellationToken cancellationToken)
        {
            var result = await _userRolesService.AddUserToRoleAsync(userId.ToString(), roleName);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}