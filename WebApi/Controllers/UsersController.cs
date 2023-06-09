﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class UsersController : ControllerBase
{
	private readonly CustomerProfileService _customerProfileService;

	public UsersController(CustomerProfileService customerProfileService)
	{
		_customerProfileService = customerProfileService;
	}

	[HttpGet("CustomerProfile")]
	[Authorize]
	public async Task<IActionResult> GetProfile()
	{
		string bearerToken = HttpContext.Request.Headers["Authorization"]!;
		var token = bearerToken.Split(" ");
		var customerProfile = await _customerProfileService.GetCustomerProfile(token[1]);

		if (customerProfile == null)
		{
			return NotFound();
		}

		return Ok(customerProfile);
	}

	[HttpPut("CustomerProfile/Update")]
	[Authorize]
	public async Task<IActionResult> UpdateProfile(CustomerUpdateSchema schema)
	{
		if (ModelState.IsValid)
		{
			if (await _customerProfileService.UpdateCustomerProfileAsync(schema))
				return Ok();

			return Problem();
		}

		return BadRequest();
	}
}
