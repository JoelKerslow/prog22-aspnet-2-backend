using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CategoryRepository _categoryRepository;

		public CategoriesController(CategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _categoryRepository.GetAllAsync());
		}
	}
}
