using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
	public class CartItemEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int CartId { get; set; }
		public CartEntity Cart { get; set; } = null!;

		[Required]
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; } = null!;


		[Required]
		public int Quantity { get; set; }


		public static implicit operator CartItemDto(CartItemEntity entity)
		{
			return new CartItemDto
			{
				Id = entity.Id,
				CartId = entity.CartId,
				ProductId = entity.ProductId,
				Quantity = entity.Quantity,
				Product = entity.Product
			};
		}
	}
}
