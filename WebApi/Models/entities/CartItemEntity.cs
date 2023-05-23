using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;
using WebApi.Models.entities;

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

		public static implicit operator OrderDetailsEntity(CartItemEntity entity)
		{
			return new OrderDetailsEntity
			{
				ProductId = entity.ProductId,
				Quantity = entity.Quantity,
			};
		}
	}
}
