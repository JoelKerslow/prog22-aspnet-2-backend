using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Test.UnitTests.Controllers
{
    public class ProductReviewsControllerTests
    {
        private readonly Mock<IProductReviewService> _mockProductReviewService;
        private readonly ProductReviewsController _controller;

        public ProductReviewsControllerTests()
        {
            _mockProductReviewService = new Mock<IProductReviewService>();
            _controller = new ProductReviewsController(_mockProductReviewService.Object);
        }

        [Fact]
        public async Task PostReview_ValidModel_ReturnsCreatedResult()
        {
            // Arrange
            var schema = new ProductReviewSchema();
            _mockProductReviewService.Setup(s => s.CreateReviewAsync(schema)).ReturnsAsync(true);

            // Act
            var result = await _controller.PostReview(schema);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task PostReview_InvalidModel_ReturnsBadRequestResult()
        {
            // Arrange
            var schema = new ProductReviewSchema();
            _controller.ModelState.AddModelError("Rating", "The Rating field is required.");

            // Act
            var result = await _controller.PostReview(schema);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetAllReviews_ReturnsOkResult()
        {
            // Arrange
            int productId = 1;
            var reviews = new List<ProductReviewDto>();

            _mockProductReviewService.Setup(s => s.GetAllAsync(productId)).ReturnsAsync(reviews);

            // Act
            var result = await _controller.GetAllReviews(productId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
