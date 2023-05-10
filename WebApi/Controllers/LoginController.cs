using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthService _authService;

        public LoginController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("GoogleLogin")]
        public async Task<IActionResult> GoogleLogin(string accessToken)
        {
            var jwtToken = await _authService.SocialLoginAsync("Google", accessToken);
            if (!string.IsNullOrEmpty(jwtToken))
                return Ok(jwtToken);

            return BadRequest("Invalid access token");
        }

        [HttpPost("FacebookLogin")]
        public async Task<IActionResult> FacebookLogin(string accessToken)
        {
            var jwtToken = await _authService.SocialLoginAsync("Facebook", accessToken);
            if (!string.IsNullOrEmpty(jwtToken))
                return Ok(jwtToken);

            return BadRequest("Invalid access token");
        }

        [HttpPost("TwitterLogin")]
        public async Task<IActionResult> TwitterLogin(string accessToken)
        {
            var jwtToken = await _authService.SocialLoginAsync("Twitter", accessToken);
            if (!string.IsNullOrEmpty(jwtToken))
                return Ok(jwtToken);

            return BadRequest("Invalid access token");
        }
    }
}
