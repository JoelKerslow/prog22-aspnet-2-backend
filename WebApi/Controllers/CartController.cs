using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly CartService _cartService;

		public CartController(CartService cartService)
		{
			_cartService = cartService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetCart()
		{
			var cart = await _cartService.GetUserCartAsync(GetBearerToken());

			if (cart == null)
			{
				return NotFound();
			}
			return Ok(cart);
		}

		[HttpPost("Item/Create")]
		[Authorize]
		public async Task<IActionResult> CreateItem(CartItemSchema schema)
		{
			await _cartService.GetUserCartAsync(GetBearerToken());

			if (ModelState.IsValid)
			{
				var cartItem = await _cartService.AddCartItemAsync(GetBearerToken(), schema);
				return Created("", cartItem);
			}

			return BadRequest();
		}

		[HttpPut("Item/Update")]
		[Authorize]
		public async Task<IActionResult> UpdateCartItemQuantity(CartItemSchema schema)
		{
			if (ModelState.IsValid)
			{
				await _cartService.UpdateCartItemAsync(GetBearerToken(), schema);
				return Ok();
			}
			return BadRequest();
		}

		[HttpDelete("Item/Delete")]
		[Authorize]
		public async Task<IActionResult> DeleteCartItem(int productId)
		{
			await _cartService.DeleteCartItemAsync(GetBearerToken(), productId);
			return NoContent();
		}

		[HttpDelete("Items/Delete")]
		[Authorize]
		public async Task<IActionResult> DeleteCartItems()
		{
			await _cartService.DeleteCartItemsAsync(GetBearerToken());
			return NoContent();
		}

		[HttpPut("Apply/PromoCode")]
		[Authorize]
		public async Task<IActionResult> ApplyPromoCode(string? promoCode)
		{
			await _cartService.ApplyPromoCodeAsync(GetBearerToken(), promoCode!);
			return Ok();
		}

		private string GetBearerToken()
		{
			string bearerToken = HttpContext.Request.Headers["Authorization"]!;
			var token = bearerToken.Split(" ");
			return token[1];
		}
	}
}

