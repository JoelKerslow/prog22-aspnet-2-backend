using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly AuthService _authService;

	public AuthenticationController(AuthService authService)
	{
		_authService = authService;
	}

	[HttpPost("Register")]
	public async Task<IActionResult> Register(CustomerRegisterSchema schema)
	{
		if (ModelState.IsValid)
		{
			if (await _authService.RegisterAsync(schema))
				return Created("", null);

			return Conflict();
		}

		return BadRequest();
	}

	[HttpPost("Login")]
	public async Task<IActionResult> Login(CustomerLoginSchema schema)
	{
		if (ModelState.IsValid)
		{
			var token = await _authService.LoginAsync(schema);
			if (!string.IsNullOrEmpty(token))
				return Ok(token);
		}

		return BadRequest("Incorrect email or password");
	}
}
