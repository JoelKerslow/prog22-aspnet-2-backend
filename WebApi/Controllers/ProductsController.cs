using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[UseApiKey]
	public class ProductsController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("All")]
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

		[HttpGet("Category")]
		public async Task<IActionResult> GetByCategory(int categoryId)
		{
			return Ok(await _productService.GetByCategoryAsync(categoryId));
		}

		[HttpGet("Department")]
		public async Task<IActionResult> GetByDepartment(int departmentId)
		{
			return Ok(await _productService.GetByDepartmentAsync(departmentId));
		}

		[HttpGet("Category/Department")]
		public async Task<IActionResult> GetByCategoryAndDepartment(int categoryId, int departmentId)
		{
			return Ok(await _productService.GetByCategoryAndDepartmentAsync(categoryId, departmentId));
		}

		[HttpGet("Tag")]
		public async Task<IActionResult> GetByTag(int tagId)
		{
			return Ok(await _productService.GetByTagAsync(tagId));
		}

		[HttpGet("Id")]
		public async Task<IActionResult> GetById(int productId)
		{
			return Ok(await _productService.GetByIdAsync(productId));
		}

		[HttpGet]
		public async Task<IActionResult> Search(string searchValue)
		{
			return Ok(await _productService.SearchAsync(searchValue));
		}

	}
}
