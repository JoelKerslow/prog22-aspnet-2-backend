using WebApi.Models.entities;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class WishlistDto
	{
		public int Id { get; set; }
		public int CustomerProfileId { get; set; }
		public ICollection<WishlistItemDto> WishlistItems { get; set; }  = new List<WishlistItemDto>();

		public static implicit operator WishlistDto(WishlistEntity entity)
		{
			return new WishlistDto
			{
				Id = entity.Id,
				CustomerProfileId = entity.CustomerProfileId,
				WishlistItems = entity.WishlistItems.Select(x => (WishlistItemDto)x).ToList()
			};
		}
	}
}
