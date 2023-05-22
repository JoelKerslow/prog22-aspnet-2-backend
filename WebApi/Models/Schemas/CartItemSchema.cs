using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
	public class CartItemSchema
	{
		[Required]
		public int CartId { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }


		public static implicit operator CartItemEntity(CartItemSchema schema)
		{
			return new CartItemEntity
			{
				CartId = schema.CartId,
				ProductId = schema.ProductId,
				Quantity = schema.Quantity
			};
		}
	}
}
