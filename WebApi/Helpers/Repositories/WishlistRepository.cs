using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Interfaces;
using WebApi.Models.entities;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class WishlistRepository : Repository<WishlistEntity>, IWishlistRepository
	{
		private readonly DataContext _context;


		public WishlistRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<WishlistEntity> GetAsync(Expression<Func<WishlistEntity, bool>> predicate)
		{
			var entity = await _context.Wishlists
				.Include(x => x.WishlistItems)
				.ThenInclude(x => x.Product)
				.ThenInclude(x => x.Reviews)
				.FirstOrDefaultAsync(predicate);

			if (entity != null)
				return entity;

			return null!;
		}

		public async Task<WishlistItemEntity?> GetWishlistItem(int wishlistId, int productId)
		{
			return await _context.WishlistItems.FirstOrDefaultAsync(x => x.WishlistId == wishlistId && x.ProductId == productId);
		}

		public async Task AddWishlistItemAsync(WishlistItemEntity entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteWIshlistItem(int wishlistId, int productId)
		{
			var wishlistItem = await GetWishlistItem(wishlistId, productId);

			if (wishlistItem != null)
			{
				_context.WishlistItems.Remove(wishlistItem);
				await _context.SaveChangesAsync();
			}
		}
	}
}
