using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[UseApiKey]
	public class ShowcaseController : ControllerBase
    {
        private readonly ShowcaseService _showcaseService;

        public ShowcaseController(ShowcaseService showcaseService)
        {
            _showcaseService = showcaseService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _showcaseService.GetAllAsync());
        }
    }
}
