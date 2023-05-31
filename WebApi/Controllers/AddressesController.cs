using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Helpers.Services;
using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService service)
        {
            _addressService = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(int userID)
        {
            var addresses = await _addressService.GetAllByUserIdAsync(userID);

            return Ok(addresses);
        }

        [HttpPut("CustomerAddress/Update")]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(AddressUpdateSchema schema)
        {
            if (ModelState.IsValid)
            {
                if (await _addressService.UpdateCustomerAddressAsync(schema))
                    return Ok();

                return Problem();
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAddress(AddressSchema schema)
        {
            if (ModelState.IsValid)
            {
                var address = await _addressService.AddAsync(schema);

                return Created("", address);
            }

            return BadRequest();
        }
    }
}
