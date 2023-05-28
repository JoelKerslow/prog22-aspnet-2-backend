using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WishlistController : ControllerBase
	{

		private readonly WishlistService _wishlistService;

		public WishlistController(WishlistService wishlistService)
		{
			_wishlistService = wishlistService;	
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetCart()
		{
			var cart = await _wishlistService.GetUserWishlistAsync(GetBearerToken());

			if (cart == null)
			{
				return NotFound();
			}
			return Ok(cart);
		}

		[HttpPost("Item/Create")]
		[Authorize]
		public async Task<IActionResult> CreateItem(WishlistItemSchema schema)
		{
			await _wishlistService.GetUserWishlistAsync(GetBearerToken());
			if (ModelState.IsValid)
			{
				var wishlistItem = await _wishlistService.AddWishlistItemAsync(GetBearerToken(), schema);
				return Created("", wishlistItem);
			}
			return BadRequest();
		}

		[HttpDelete("Item/Delete")]
		[Authorize]
		public async Task<IActionResult> DeleteWishlistItem(int productId)
		{
			await _wishlistService.DeleteWishlistItemAsync(GetBearerToken(), productId);
			return NoContent();
		}

		private string GetBearerToken()
		{
			string bearerToken = HttpContext.Request.Headers["Authorization"]!;
			var token = bearerToken.Split(" ");
			return token[1];
		}
	}
}
