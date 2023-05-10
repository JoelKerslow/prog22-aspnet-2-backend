using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("GoogleLogin")]
        public IActionResult GoogleLogin()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(authProperties, "Google");
        }

        [HttpGet("GoogleResponse")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Google");
            if (!result.Succeeded) return BadRequest();

            var claimsIdentity = new ClaimsIdentity(result.Principal.Claims, "Google");
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", principal);

            return Redirect("/");
        }

        [HttpGet("FacebookLogin")]
        public IActionResult FacebookLogin()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("FacebookResponse") };
            return Challenge(authProperties, "Facebook");
        }

        [HttpGet("FacebookResponse")]
        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Facebook");
            if (!result.Succeeded) return BadRequest();

            var claimsIdentity = new ClaimsIdentity(result.Principal.Claims, "Facebook");
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", principal);

            return Redirect("/");
        }

        [HttpGet("TwitterLogin")]
        public IActionResult TwitterLogin()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("TwitterResponse") };
            return Challenge(authProperties, "Twitter");
        }

        [HttpGet("TwitterResponse")]
        public async Task<IActionResult> TwitterResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Twitter");
            if (!result.Succeeded) return BadRequest();

            var claimsIdentity = new ClaimsIdentity(result.Principal.Claims, "Twitter");
            var principal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Cookies", principal);

            return Redirect("/");
        }
    }
}
