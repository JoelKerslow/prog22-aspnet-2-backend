using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;


namespace WebApi.Helpers.Services
{
	public class CartService
	{
		private readonly CartRepository _cartRepo;
		private readonly ProductRepository _productRepo;
		private readonly CustomerProfileService _customerProfileService;
		private readonly PromoCodeService _promoCodeService;
		JwtService _jwtService;

		public CartService(CartRepository cartRepo,ProductRepository productRepo,CustomerProfileService customerProfileService,JwtService jwtService, PromoCodeService promoCodeService)
		{
			_cartRepo = cartRepo;
			_productRepo = productRepo;
			_customerProfileService = customerProfileService;
			_promoCodeService = promoCodeService;
			_jwtService = jwtService;
		}

		public async Task<CartEntity> CreateCartAsync(string token, CartSchema schema)
		{
			var userId = _jwtService.GetIdFromToken(token);

			CartEntity entity = schema;
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			entity.CustomerProfileId = customerProfile.Id;
			entity.CreatedAt = DateTime.Now;

			var cart = await _cartRepo.GetAsync(x => x.CustomerProfile.UserId == userId);

			if (cart == null)
			{
				return await _cartRepo.AddAsync(entity);
			}
			return cart;
		}

		public async Task<CartDto> GetUserCartAsync(string token)
		{
			var userId = _jwtService.GetIdFromToken(token);
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			var cart = await _cartRepo.GetAsync(x => x.CustomerProfileId == customerProfile.Id);

			if (cart != null)
			{
				if (!cart.IsActive)
				{
					await _cartRepo.RemoveAsync(cart);
					return null!;
				}
				else
					return cart;
			}
			return null!;
		}

		public async Task<CartItemEntity> AddCartItemAsync(string token, CartItemSchema schema)
		{
			var cart = await GetUserCartAsync(token);
			var product = await _productRepo.GetAsync(x => x.Id == schema.ProductId);
			var cartItem = await _cartRepo.GetCartItem(cart.Id, product.Id);

			if (cartItem == null)
			{
				schema.CartId = cart.Id;
				schema.ProductId = product.Id;
				schema.Quantity = 1;
			}
			else
				schema.Quantity = cartItem.Quantity;
			return await _cartRepo.AddCartItemAsync(schema);
		}

		public async Task<CartItemDto> UpdateCartItemAsync(string token, CartItemSchema schema)
		{
			var cart = await GetUserCartAsync(token);
			schema.CartId = cart.Id;

			var cartItem = await _cartRepo.GetCartItem(schema.CartId, schema.ProductId) ?? throw new Exception("Cart item not found");
			var product = await _productRepo.GetAsync(x => x.Id == schema.ProductId) ?? throw new Exception("Product not found");
			if (product.Stock < schema.Quantity)
			{
				throw new Exception("Insufficient stock");
			}
			cartItem.Quantity = schema.Quantity;
			return await _cartRepo.UpdateCartItem(cartItem);
		}

		public async Task<CartItemDto> DeleteCartItemAsync(string token, int productId)
		{
			var cart = await GetUserCartAsync(token);
			CartItemEntity entity = new()
			{
				CartId = cart.Id,
				ProductId = productId
			};
			return await _cartRepo.DeleteCartItem(entity);
		}

		public async Task<CartDto> DeleteCartItemsAsync(string token)
		{
			var cart = await GetUserCartAsync(token);
			CartEntity entity = new()
			{
				Id = cart.Id
			};
			return await _cartRepo.DeleteCartItems(entity);
		}

		public async Task<decimal> CalculatePriceAsync(string token, string code)
		{
			var cart = await GetUserCartAsync(token);
			if (cart.CartItems.Count == 0)
			{
				throw new Exception("No products in the cart");
			}
			var productId = cart.CartItems.First().ProductId;
			var product = await _productRepo.GetAsync(x => x.Id == productId);
			var totalPrice = cart.CartItems.Sum(x => x.Quantity * product.Price);
			
			if (!string.IsNullOrWhiteSpace(code))
			{
				var promoCode = await _promoCodeService.ValidatePromoCode(code);
				if (promoCode != null)
				{
					cart.PromoCodeId = promoCode.Id;
					cart.PromoCode = promoCode;
					totalPrice *= (100m - promoCode.Discount) / 100m;
				}
				else
					throw new Exception("Invalid promo code");
			}
			cart.TotalPrice = totalPrice;
			return totalPrice;
		}
	}
}
