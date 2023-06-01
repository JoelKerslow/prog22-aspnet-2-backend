using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Filters;
using WebApi.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IProductReviewService _productReviewService;

        public ProductReviewsController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostReview(ProductReviewSchema schema)
        {
            if (ModelState.IsValid)
            {
                if (await _productReviewService.CreateReviewAsync(schema))
                    return Created("", null);

                return Problem();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int productId)
        {
            var reviews = await _productReviewService.GetAllAsync(productId);
            return Ok(reviews);
        }
    }
}
