using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class AuthenticationController : ControllerBase
{
	private readonly IAuthService _authService;

	public AuthenticationController(IAuthService authService)
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

	[Authorize]
	[HttpGet("Authorize")]
	public IActionResult Authorize()
	{
		return Ok();
	}
}
