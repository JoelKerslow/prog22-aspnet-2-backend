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

		[HttpPost("Create")]
		[Authorize]
		public async Task<IActionResult> Create(CartSchema schema)
		{
			if (ModelState.IsValid)
			{
				var cart = await _cartService.CreateCartAsync(GetBearerToken(), schema);
				return Created("", cart);
			}
			return BadRequest();
		}

		[HttpPost("Item/Create")]
		[Authorize]
		public async Task<IActionResult> CreateItem(CartItemSchema schema)
		{
			await _cartService.GetUserCartAsync(GetBearerToken());
			if (ModelState.IsValid)
			{
				var cart = await _cartService.AddCartItemAsync(GetBearerToken(), schema);
				return Created("", cart);
			}
			return BadRequest();
		}

		[HttpPut("Item/Update")]
		[Authorize]
		public async Task<IActionResult> UpdateCartItemQuantity(CartItemSchema schema)
		{
			if (ModelState.IsValid)
			{
				var result = await _cartService.UpdateCartItemAsync(GetBearerToken(), schema);
				return Created("", result);
			}
			return BadRequest();
		}

		[HttpDelete("Item/Delete")]
		[Authorize]
		public async Task<IActionResult> DeleteCartItem(int productId)
		{
			return Ok(await _cartService.DeleteCartItemAsync(GetBearerToken(), productId));
		}

		[HttpDelete("Items/Delete")]
		[Authorize]
		public async Task<IActionResult> DeleteCartItems()
		{
			return Ok(await _cartService.DeleteCartItemsAsync(GetBearerToken()));
		}

		[HttpGet("Checkout")]
		public async Task<IActionResult> CalculatePrice(string? promoCode)
		{ 
			return Ok(await _cartService.CalculatePriceAsync(GetBearerToken(), promoCode!));
		}

		private string GetBearerToken()
		{
			string bearerToken = HttpContext.Request.Headers["Authorization"]!;
			var token = bearerToken.Split(" ");
			return token[1];
		}
	}
}

