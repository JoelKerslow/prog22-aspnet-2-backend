using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class CartItemDto
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }


		public static implicit operator CartItemDto(CartItemEntity entity)
		{
			return new CartItemDto
			{
				Id = entity.Id,
				CartId = entity.CartId,
				ProductId = entity.ProductId,
				Quantity = entity.Quantity
			};
		}
	}
}
