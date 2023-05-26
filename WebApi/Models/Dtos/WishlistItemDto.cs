using WebApi.Models.entities;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class WishlistItemDto
	{
		public int Id { get; set; }
		public int WishlistId { get; set; }
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; } = null!;


		public static implicit operator WishlistItemDto(WishlistItemEntity entity)
		{
			return new WishlistItemDto
			{
				Id = entity.Id,
				WishlistId = entity.WishlistId,
				ProductId = entity.ProductId,
				Product = entity.Product
			};
		}
	}
}
