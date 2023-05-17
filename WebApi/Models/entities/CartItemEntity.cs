using System.ComponentModel.DataAnnotations;

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

		[Required]
		public int Quantity { get; set; }
	}
}
