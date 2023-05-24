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
		private readonly JwtService _jwtService;

		public CartService(CartRepository cartRepo,ProductRepository productRepo,CustomerProfileService customerProfileService,JwtService jwtService, PromoCodeService promoCodeService)
		{
			_cartRepo = cartRepo;
			_productRepo = productRepo;
			_customerProfileService = customerProfileService;
			_promoCodeService = promoCodeService;
			_jwtService = jwtService;
		}

		public async Task<CartDto> CreateCartAsync(string token)
		{
			var userId = _jwtService.GetIdFromToken(token);
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			var existingCart = await _cartRepo.GetAsync(x => x.CustomerProfile.UserId == userId);

			if (existingCart != null)
			{
				return existingCart;
			}

			var cart = new CartEntity
			{
				CustomerProfileId = customerProfile.Id,
				CreatedAt = DateTime.Now,
				IsActive = true
			};

			return await _cartRepo.AddAsync(cart);
		}

		public async Task<CartDto> GetUserCartAsync(string token)
		{
			var userId = _jwtService.GetIdFromToken(token);
			var customerProfile = await _customerProfileService.GetCustomerProfile(token);
			var cart = await _cartRepo.GetAsync(x => x.CustomerProfile.UserId == userId);

			if (cart == null)
			{
				return await CreateCartAsync(token);
			}

			if (!cart.IsActive)
			{
				await _cartRepo.RemoveAsync(cart);
				return null!;
			}

			CartDto cartDto = cart;
			foreach (var item in cart.CartItems)
			{
				cartDto.CartItems.Add(item);
			}
			return cartDto;
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
				cartItem.Quantity = 1;

				await _cartRepo.AddCartItemAsync(cartItem);
			}
			else
			{
				cartItem.Quantity += 1;

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
