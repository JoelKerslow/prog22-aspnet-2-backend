using Moq;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;
using WebApi.Models.Entities;
using System.Linq.Expressions;
using WebApi.Models.entities;
using Shouldly;
using WebApi.Interfaces;

namespace WebApi.Test.UnitTests.Services
{
	public class WishlistServiceTests
	{
		private Mock<IWishlistRepository> _wishlistRepo;
		private Mock<IProductRepository> _productRepo;
		private Mock<ICustomerProfileService> _customerProfileService;
		private IWishlistService _wishlistService;
		private IProductService _productService;

		public WishlistServiceTests()
		{
			_wishlistRepo = new Mock<IWishlistRepository>();
			_productRepo = new Mock<IProductRepository>();
			_customerProfileService = new Mock<ICustomerProfileService>();
			_wishlistService = new WishlistService(_wishlistRepo.Object, _productRepo.Object, _customerProfileService.Object);
			_productService = new ProductService(_productRepo.Object);
		}


		[Fact]
		public async Task GetUserWishlistAsync_WithValidToken()
		{
			var token = "valid_token";
			var customerProfile = new CustomerProfileDto
			{
				Id = 1,
				UserId = "user"
			};
			var wishlist = new WishlistEntity
			{
				Id = 1,
				CustomerProfileId = customerProfile.Id
			};
	
			_customerProfileService
				.Setup(service => service.GetCustomerProfile(token))
				.ReturnsAsync(customerProfile);

			_wishlistRepo
				.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<WishlistEntity, bool>>>()))
				.ReturnsAsync(wishlist);

			var result = await _wishlistService.GetUserWishlistAsync(token);

			result.CustomerProfileId.ShouldBe(wishlist.CustomerProfileId);
			result.Id.ShouldBe(wishlist.Id);
		}


		[Fact]
		public async Task AddWishlistItemAsync_When_WishlistItem_Is_Not_Found()
		{
			var token = "valid_token";
			var product = new ProductDto
			{
				Id = 1
			};
			var schema = new WishlistItemSchema
			{
				ProductId = product.Id
			};
			var customerProfile = new CustomerProfileDto
			{
				Id = 1,
				UserId = "1"
			};
			var wishlist = new WishlistEntity
			{
				Id = 1,
				CustomerProfileId = customerProfile.Id
			};
			var wishlistItem = new WishlistItemDto
			{
				WishlistId = wishlist.Id,
				ProductId = product.Id,
				Product = product
			};

			_customerProfileService
				.Setup(service => service.GetCustomerProfile(token))
				.ReturnsAsync(customerProfile);

			_wishlistRepo
				.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<WishlistEntity, bool>>>()))
				.ReturnsAsync(wishlist);

			_productRepo
				.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
				.ReturnsAsync(product);

			_wishlistRepo
				.Setup(repo => repo.GetWishlistItem(wishlist.Id, product.Id))
				.ReturnsAsync((WishlistItemEntity?)null);

			_wishlistRepo
				.Setup(repo => repo.AddWishlistItemAsync(It.Is<WishlistItemEntity>(i => i.ProductId == product.Id && i.WishlistId == wishlist.Id)))
				.Verifiable();

			var result = await _wishlistService.AddWishlistItemAsync(token, schema);


			result.WishlistId.ShouldBe(wishlist.Id);
			result.ProductId.ShouldBe(product.Id);

			_wishlistRepo.Verify();
		}

		[Fact]
		public async Task DeleteWishlistItemAsync_Should_Delete_Wishlist_Item()
		{
			var token = "valid_token";
			var product = new ProductDto
			{
				Id = 1
			};

			var customerProfile = new CustomerProfileDto
			{
				Id = 1,
				UserId = "1"
			};

			var wishlist = new WishlistEntity
			{
				Id = 1,
				CustomerProfileId = customerProfile.Id,
			};

			_customerProfileService
			.Setup(service => service.GetCustomerProfile(token))
			.ReturnsAsync(customerProfile);

			_wishlistRepo
				.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<WishlistEntity, bool>>>()))
				.ReturnsAsync(wishlist);

			_productRepo
				.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<ProductEntity, bool>>>()))
				.ReturnsAsync(product);

			_wishlistRepo
				.Setup(repo => repo.DeleteWIshlistItem(wishlist.Id, product.Id))
				.Verifiable();

			await _wishlistService.DeleteWishlistItemAsync(token, product.Id);

			_wishlistRepo.Verify();
		}
	}
}

