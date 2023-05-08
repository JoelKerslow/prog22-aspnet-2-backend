using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		private readonly TagRepository _tagRepository;

		public TagsController(TagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _tagRepository.GetAllAsync());
		}
	}
}
