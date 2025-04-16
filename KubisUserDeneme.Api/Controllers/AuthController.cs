using Microsoft.AspNetCore.Mvc;
using KubisUserDeneme.DTO;
using KubisUserDeneme.Service.Services;


namespace KubisUserDeneme.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO request, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO request, CancellationToken cancellationToken)
        {
            var result = await _authService.ChangePasswordAsync(request.Id.ToString(), request.OldPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            var token = await _authService.GeneratePasswordResetTokenAsync(email);
            if (token == null)
            {
                return BadRequest(new { Message = "Kullanici bulunamadi" });
            }
            return Ok(new { Token = token });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingTokenDTO request, CancellationToken cancellationToken)
        {
            var result = await _authService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request);
            if (!result)
            {
                return BadRequest(new { Message = "Kullanici bulunamadi veya sifre hatali" });
            }

            return Ok(new { Message = "Giriş Başarılı" });
        }
    }
}