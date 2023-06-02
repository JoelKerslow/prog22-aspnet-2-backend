using System.Linq.Expressions;
using WebApi.Models.entities;
using WebApi.Models.Entities;
namespace WebApi.Interfaces
{
    public interface IWishlistRepository : IRepository<WishlistEntity>
	{
        Task AddWishlistItemAsync(WishlistItemEntity entity);
        Task DeleteWIshlistItem(int wishlistId, int productId);
        Task<WishlistEntity> GetAsync(Expression<Func<WishlistEntity, bool>> predicate);
        Task<WishlistItemEntity?> GetWishlistItem(int wishlistId, int productId);
    }
}