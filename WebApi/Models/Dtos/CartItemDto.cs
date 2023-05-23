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

	}
}
