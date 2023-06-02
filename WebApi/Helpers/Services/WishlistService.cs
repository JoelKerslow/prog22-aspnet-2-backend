using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class WishlistService : IWishlistService
	{
		private readonly IWishlistRepository _wishlistRepo;
		private readonly IProductRepository _productRepo;
		private readonly ICustomerProfileService _customerProfileService;

		public WishlistService(IWishlistRepository wishlistRepo, IProductRepository productRepo, ICustomerProfileService customerProfileService)
		{
			_wishlistRepo = wishlistRepo;
			_productRepo = productRepo;
			_customerProfileService = customerProfileService;
		}

		public async Task<WishlistDto> GetUserWishlistAsync(string token)
		{
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			var wishlist = await _wishlistRepo.GetAsync(x => x.CustomerProfile.UserId == customerProfile.UserId);

			if (wishlist == null)
			{
				var newWishlist = new WishlistEntity
				{
					CustomerProfileId = customerProfile.Id,
				};
				return await _wishlistRepo.AddAsync(newWishlist);
			}
			return wishlist;
		}

		public async Task<WishlistItemDto> AddWishlistItemAsync(string token, WishlistItemSchema schema)
		{
			var wishlist = await GetUserWishlistAsync(token);
			var product = await _productRepo.GetAsync(x => x.Id == schema.ProductId);
			var wishlistItem = await _wishlistRepo.GetWishlistItem(wishlist.Id, product.Id);

			if (wishlistItem == null)
			{
				wishlistItem = schema;
				wishlistItem.WishlistId = wishlist.Id;
				wishlistItem.Product = product;

				await _wishlistRepo.AddWishlistItemAsync(wishlistItem);
			}

			return wishlistItem;
		}

		public async Task DeleteWishlistItemAsync(string token, int productId)
		{
			var wishlist = await GetUserWishlistAsync(token);
			await _wishlistRepo.DeleteWIshlistItem(wishlist.Id, productId);
		}
	}
}
