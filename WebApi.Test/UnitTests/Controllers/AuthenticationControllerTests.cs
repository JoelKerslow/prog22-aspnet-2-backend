using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Helpers.Services;
using WebApi.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Test.UnitTests.Controllers
{
    public class AuthenticationControllerTests
    {
        private Mock<IAuthService> _authServiceMock;
        private AuthenticationController _controller;

        public AuthenticationControllerTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _controller = new AuthenticationController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Register_ShouldRegisterNewUser_ReturnsCreated()
        {
            //Arrange
            var schema = new CustomerRegisterSchema
            {
                FirstName = "Olle",
                LastName = "Hammarsson",
                Email = "olle@domain.com",
                Password = "password"
            };

            _authServiceMock.Setup(s => s.RegisterAsync(schema)).ReturnsAsync(true);

            //Act
            var result = await _controller.Register(schema);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task Register_ShouldReturnConflict_ReturnsConflict()
        {
            //Arrange
            var schema = new CustomerRegisterSchema
            {
                LastName = "Hammarsson",
                Email = "olle@domain.com",
            };
            _authServiceMock.Setup(s => s.RegisterAsync(schema));

            //Act
            var result = await _controller.Register(schema);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ConflictResult>(result);
        }

        [Fact]
        public async Task Register_ShouldReturnBadRequest_ReturnsBadRequest()
        {
            // Arrange
            var schema = new CustomerRegisterSchema
            {
                FirstName = "Olle",
                LastName = "Hammarsson"
            };
            _controller.ModelState.AddModelError("ModelError", "Model state not valid");

            // Act
            var result = await _controller.Register(schema) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

    }
}
