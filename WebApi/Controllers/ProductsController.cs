using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[UseApiKey]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("All")]
		public async Task<IActionResult> GetAllProducts()
		{
			return Ok(await _productService.GetAllProductsAsync());
		}

		[HttpGet("Sizes")]
		public async Task<IActionResult> GetSizes()
		{
			return Ok(await _productService.GetAllSizesAsync());
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(ProductSchema schema)
		{
			schema.CreatedAt = DateTime.Now;
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
			return Ok(await _productService.GetProductByIdAsync(productId));
		}

		[HttpGet("Search")]
		public async Task<IActionResult> Search(string searchValue)
		{
			return Ok(await _productService.SearchAsync(searchValue));
		}

		[HttpGet("Newest")]
		public async Task<IActionResult> GetByNewestDate()
		{
			var products = await _productService.GetByNewestDateAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Oldest")]
		public async Task<IActionResult> GetByOldestDate()
		{
			var products = await _productService.GetByOldestDateAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Price")]
		public async Task<IActionResult> GetByPrice(int amount)
		{
			var products = await _productService.GetByPriceAsync(amount);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Price/Highest")]
		public async Task<IActionResult> GetByHighestPrice()
		{
			var products = await _productService.GetByHighestPriceAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Price/Lowest")]
		public async Task<IActionResult> GetByLowestPrice()
		{
			var products = await _productService.GetByLowestPriceAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Color")]
		public async Task<IActionResult> GetByColor(string color)
		{
			var products = await _productService.GetByColorAsync(color);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Size")]
		public async Task<IActionResult> GetBySize(string size)
		{
			var products = await _productService.GetBySizeAsync(size);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("Size/Color/Price/Department/Tag")]
		public async Task<IActionResult> GetBySizeColorPriceDepartmentTag(int minPrice, int maxPrice, int tagId, int departmentId, string size, string color)
		{
			var products = await _productService.GetBySizeColorPriceDepartmentTagAsync(minPrice, maxPrice, tagId, departmentId, size, color);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}
	}
}
