using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Test.UnitTests.Controllers
{
    public class AddressesControllerTests
    {
        private Mock<IAddressService> _mockAddressService;
        private AddressesController _addressController;

        public AddressesControllerTests()
        {
            _mockAddressService = new Mock<IAddressService>();
            _addressController = new AddressesController(_mockAddressService.Object);
        }

        [Fact]
        public async Task GetAll_ValidUserID_ReturnsOkWithAddresses()
        {
            
            int userId = 123;

            var expectedAddresses = new List<AddressDto>
            {
                
            };

            _mockAddressService.Setup(x => x.GetAllByUserIdAsync(userId)).ReturnsAsync(expectedAddresses);

            // Act
            var result = await _addressController.GetAll(userId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Same(expectedAddresses, result.Value);
        }

        [Fact]
        public async Task AddAddress_ValidSchema_ReturnsCreatedWithAddress()
        {
            
            var schema = new AddressSchema();
            var expectedAddress = new AddressEntity();

            _mockAddressService.Setup(x => x.AddAsync(schema)).ReturnsAsync(expectedAddress);

            
            var result = await _addressController.AddAddress(schema) as CreatedResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);

            var actualAddress = result.Value as AddressEntity;
            Assert.NotNull(actualAddress);
        }



    }
}
