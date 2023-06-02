using Moq;
using System.Linq.Expressions;
using WebApi.Helpers.Repositories.Interfaces;
using WebApi.Helpers.Services;
using WebApi.Interfaces;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Test.UnitTests.Services
{
    public class CustomerProfileServiceTests
    {
        private readonly Mock<ICustomerProfileRepository> _customerProfileRepositoryMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly ICustomerProfileService _customerProfileServiceSut;

        public CustomerProfileServiceTests()
        {
            _customerProfileRepositoryMock = new Mock<ICustomerProfileRepository>();
            _jwtServiceMock = new Mock<IJwtService>();
            _customerProfileServiceSut = new CustomerProfileService(_customerProfileRepositoryMock.Object, _jwtServiceMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ReturnsCreatedCustomerProfile()
        {
            // Arrange
            var userId = "user123";
            var entity = new CustomerProfileEntity { Id = 1, FirstName = "Joel", LastName = "Kerslow", Email = "test@test.com" };
            _customerProfileRepositoryMock.Setup(x => x.AddAsync(entity)).ReturnsAsync(entity);

            // Act
            var result = await _customerProfileServiceSut.CreateAsync(entity, userId);

            // Assert
            Assert.Equal(entity, result);
            _customerProfileRepositoryMock.Verify(x => x.AddAsync(entity), Times.Once);
        }

        [Fact]
        public async Task UpdateCustomerProfileAsync_WithExistingCustomer_ReturnsTrue()
        {
            // Arrange
            var schema = new CustomerUpdateSchema { Id = 1, FirstName = "Joel", LastName = "Kerslow" };
            var customer = new CustomerProfileEntity { Id = 1, FirstName = "Joelol", LastName = "Kerslow" };
            _customerProfileRepositoryMock.Setup(x => x.GetAsync(It.IsAny<Expression<Func<CustomerProfileEntity, bool>>>()))
                .ReturnsAsync(customer);

            // Act
            var result = await _customerProfileServiceSut.UpdateCustomerProfileAsync(schema);

            // Assert
            Assert.True(result);
            _customerProfileRepositoryMock.Verify(x => x.UpdateAsync(customer), Times.Once);
        }
    }
}
