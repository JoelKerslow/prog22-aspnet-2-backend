using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
	public class CartItemSchema
	{
		[Required]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }


		public static implicit operator CartItemEntity(CartItemSchema schema)
		{
			return new CartItemEntity
			{
				ProductId = schema.ProductId,
				Quantity = schema.Quantity
			};
		}
	}
}
