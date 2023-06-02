using WebApi.Helpers.Repositories;
using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;


namespace WebApi.Helpers.Services
{
	public class CartService
	{
		private readonly CartRepository _cartRepo;
		private readonly IProductRepository _productRepo;
		private readonly ICustomerProfileService _customerProfileService;
		private readonly PromoCodeService _promoCodeService;

		public CartService(CartRepository cartRepo,IProductRepository productRepo,ICustomerProfileService customerProfileService,PromoCodeService promoCodeService)
		{
			_cartRepo = cartRepo;
			_productRepo = productRepo;
			_customerProfileService = customerProfileService;
			_promoCodeService = promoCodeService;
		}

		public async Task<CartDto> GetUserCartAsync(string token)
		{
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			var cart = await _cartRepo.GetAsync(x => x.CustomerProfile.UserId == customerProfile.UserId);

			if (cart == null)
			{
				var newCart = new CartEntity
				{
					CustomerProfileId = customerProfile.Id,
					CreatedAt = DateTime.Now,
					IsActive = true
				};
				return await _cartRepo.AddAsync(newCart);
			}

			return cart;
		}

		public async Task<CartItemDto> AddCartItemAsync(string token, CartItemSchema schema)
		{
			var cart = await GetUserCartAsync(token);
			var product = await _productRepo.GetAsync(x => x.Id == schema.ProductId);
			var cartItem = await _cartRepo.GetCartItem(cart.Id, product.Id);

			if (cartItem == null)
			{
				cartItem = schema;
				cartItem.CartId = cart.Id;
				cartItem.ProductId = product.Id;
				cartItem.Quantity = schema.Quantity;

				await _cartRepo.AddCartItemAsync(cartItem);
			}
			else
			{
				cartItem.Quantity += schema.Quantity;

				await _cartRepo.UpdateCartItem(cartItem);
			}

			return cartItem;
		}

		public async Task UpdateCartItemAsync(string token, CartItemSchema schema)
		{
			var cart = await GetUserCartAsync(token);

			var cartItem = await _cartRepo.GetCartItem(cart.Id, schema.ProductId) ?? throw new Exception("Cart item not found");
			var product = await _productRepo.GetAsync(x => x.Id == schema.ProductId) ?? throw new Exception("Product not found");
			if (product.Stock < schema.Quantity)
			{
				throw new Exception("Insufficient stock");
			}
			cartItem.Quantity = schema.Quantity;
			await _cartRepo.UpdateCartItem(cartItem);
		}

		public async Task DeleteCartItemAsync(string token, int productId)
		{
			var cart = await GetUserCartAsync(token);
			await _cartRepo.DeleteCartItem(cart.Id, productId);
		}

		public async Task DeleteCartItemsAsync(string token)
		{
			var cart = await GetUserCartAsync(token);
			await _cartRepo.DeleteCartItems(cart.Id);
		}

		public async Task ApplyPromoCodeAsync(string token, string code)
		{
			var cart = await GetUserCartAsync(token);
			if (cart.CartItems.Count == 0)
			{
				throw new Exception("No products in the cart");
			}
			var promoCode = await _promoCodeService.ValidatePromoCode(code);
			if (promoCode != null)
			{
				cart.PromoCodeId = promoCode.Id;
				cart.PromoCode = promoCode;
				await _cartRepo.UpdateByIdAsync(cart.Id, cart);
			}
			else
			{
				throw new Exception("Invalid promo code");
			}
		}
	}
}
