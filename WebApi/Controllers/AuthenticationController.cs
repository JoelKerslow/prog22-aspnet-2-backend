﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
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

	[Authorize]
	[HttpGet("Authorize")]
	public IActionResult Authorize()
	{
		return Ok();
	}

    [HttpPost("AuthorizeWithGoogle")]
    public async Task<IActionResult> AuthorizeWithGoogle()
    {
		string googleToken;

        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {
            googleToken = await reader.ReadToEndAsync();
        }

        var token = await _authService.LoginWithGoogleAsync(googleToken);

		if(string.IsNullOrEmpty(token))
			return Problem();

        return Ok(token);
    }
}
