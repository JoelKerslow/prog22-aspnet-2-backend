using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class CartRepository : Repository<CartEntity>
	{
		private readonly DataContext _context;


		public CartRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public override Task<CartEntity> GetAsync(Expression<Func<CartEntity, bool>> predicate)
		{
			return _context.Carts
				.Include(x => x.PromoCode)
				.Include(x => x.CartItems)
				.ThenInclude(x => x.Product)
				.FirstAsync(predicate);
		}

		public async Task<CartItemEntity?> GetCartItem(int cartId, int productId)
		{
			return await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == cartId && x.ProductId == productId);
		}

		public async Task AddCartItemAsync(CartItemEntity entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateCartItem(CartItemEntity entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCartItem(int cartId, int productId)
		{
			var cartItem = await GetCartItem(cartId, productId);

			if (cartItem != null)
			{
				_context.CartItems.Remove(cartItem);
				await _context.SaveChangesAsync();
			}
		}
		
		public async Task DeleteCartItems(int cartId)
		{
			var cartItems = await _context.CartItems
				.Where(x => x.CartId == cartId)
				.ToListAsync();

			foreach (var cartItem in cartItems)
			{
				_context.CartItems.Remove(cartItem);
			}

			await _context.SaveChangesAsync();
		}
	}
}

