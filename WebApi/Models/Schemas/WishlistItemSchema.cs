using WebApi.Models.entities;

namespace WebApi.Models.Schemas
{
	public class WishlistItemSchema
	{
		public int ProductId { get; set; }

		public static implicit operator WishlistItemEntity(WishlistItemSchema schema)
		{
			return new WishlistItemEntity
			{
				ProductId = schema.ProductId
			};
		}
	}
}

