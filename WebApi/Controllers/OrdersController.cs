﻿using Microsoft.AspNetCore.Mvc;
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
		public async Task<IActionResult> GetOrdersByCustomer(int customerId)
		{
			var orders = await _orderService.GetOrdersAsync(customerId);

			if(orders.Count() > 0)
			{
				return Ok(orders);	
			}

			return NotFound();
		}

		[HttpPost("/Review")]
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
