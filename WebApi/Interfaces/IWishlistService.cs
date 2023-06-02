using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface IWishlistService
    {
        Task<WishlistItemDto> AddWishlistItemAsync(string token, WishlistItemSchema schema);
        Task DeleteWishlistItemAsync(string token, int productId);
        Task<WishlistDto> GetUserWishlistAsync(string token);
    }
}