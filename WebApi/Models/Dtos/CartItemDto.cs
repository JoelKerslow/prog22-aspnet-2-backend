using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class CartItemDto
	{
		public int Id { get; set; }
		public int CartId { get; set; }

		public int ProductId { get; set; }
		public ProductDto Product { get; set; } = null!;

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

		public static implicit operator CartItemEntity(CartItemDto dto)
		{
			return new CartItemEntity
			{
				Id = dto.Id,
				CartId = dto.CartId,
				ProductId = dto.ProductId,
				Quantity = dto.Quantity,
				Product = dto.Product
			};
		}
	}
}


