using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;

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
		string token = HttpContext.Request.Headers["Authorization"]!;
		var customerProfile = await _customerProfileService.GetCustomerProfile(token);

		if (customerProfile == null)
		{
			return NotFound();
		}

		return Ok(customerProfile);
	}
}
