using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _service;

        public AddressesController(AddressService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll(int userID)
        {
            var addresses = await _service.GetAllByUserIdAsync(userID);

            return Ok(addresses);
        }
    }
}
