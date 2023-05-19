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

		public override async Task<CartEntity> GetAsync(Expression<Func<CartEntity, bool>> predicate)
		{
			var entity = await _context.Carts.Include(x => x.CartItems).FirstOrDefaultAsync(predicate);

			if (entity != null)
				return entity;

			return null!;
		}

		public async Task<CartItemEntity?> GetCartItem(int cartId, int productId)
		{
			return await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == cartId && x.ProductId == productId);
		}

		public async Task<CartItemEntity> AddCartItemAsync(CartItemEntity entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
			if (entity != null)
				return entity;
			return null!;
		}

		public async Task<CartItemEntity> UpdateCartItem(CartItemEntity entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
			if (entity != null)
				return entity;
			return null!;
		}


		public async Task<CartItemEntity> DeleteCartItem(CartItemEntity entity)
		{
			var cartItem = await GetCartItem(entity.CartId, entity.ProductId);

			if (cartItem != null)
			{
				_context.CartItems.Remove(cartItem);
				await _context.SaveChangesAsync();
			}

			if (entity != null)
				return entity;
			return null!;
		}

		public async Task<CartEntity> DeleteCartItems(CartEntity entity)
		{
			var cartItems = await _context.CartItems
				.Where(x => x.CartId == entity.Id)
				.ToListAsync();

			foreach (var cartItem in cartItems)
			{
				_context.CartItems.Remove(cartItem);
			}

			await _context.SaveChangesAsync();

			if (entity != null)
				return entity;
			return null!;
		}
	}
}

