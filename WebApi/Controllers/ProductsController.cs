using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _productService.GetAllAsync());
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(ProductSchema schema)
		{
			if (ModelState.IsValid)
			{
				var product = await _productService.CreateAsync(schema);

				return Created("", product);
			}

			return BadRequest();
		}
	}
}
