using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[UseApiKey]
	public class OrdersController : ControllerBase
	{
		private readonly OrderService _orderService;

		public OrdersController(OrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetOrdersByCustomer(int customerId)
		{
			var orders = await _orderService.GetOrdersAsync(customerId);

			if(orders.Count() > 0)
			{
				return Ok(orders);	
			}

			return NotFound();
		}

		[HttpGet("Id")]
		[Authorize]
		public async Task<IActionResult> GetOrderById(int orderId)
		{
			var order = await _orderService.GetOrderByIdAsync(orderId);

			if (order != null)
			{
				return Ok(order);
			}

			return NotFound();
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreateOrder(OrderSchema schema)
		{
            string bearerToken = HttpContext.Request.Headers["Authorization"]!;
            var token = bearerToken.Split(" ");

            if (ModelState.IsValid)
			{
				if(await _orderService.CreateOrderAsync(schema, token[1]))
				{
					return Created("", null);
				}

				return Problem();
			}

			return BadRequest();
		}

		[HttpPost("/Review")]
		[Authorize]
		public async Task<IActionResult> PostReview(OrderReviewSchema schema)
		{
			if (ModelState.IsValid)
			{
				if(await _orderService.CreateOrderReviewAsync(schema))
				{
					return Created("", null);
				}

				return Problem();
			}

			return BadRequest();
		}
	}
}
