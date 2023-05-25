using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
	public class UpdateCartItemSchema
	{
		[Required]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }

		public static implicit operator CartItemEntity(UpdateCartItemSchema schema)
		{
			return new CartItemEntity
			{
				ProductId = schema.ProductId,
				Quantity = schema.Quantity
			};
		}
	}
}
