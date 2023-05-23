using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class OrderSchema
{

	[Required]
	public int CustomerId { get; set; }

	[Required]
	public decimal TotalAmount { get; set; }

	public string? CustomerComment { get; set; }

	public int? PromoCodeId { get; set; }

	public ICollection<OrderDetailsSchema> OrderDetails { get; set; } = null!;

	public static implicit operator OrderEntity(OrderSchema schema)
	{
		return new OrderEntity
		{
			CustomerId = schema.CustomerId,
			TotalAmount = schema.TotalAmount,
			CustomerComment = schema.CustomerComment,
			PromoCodeId = schema.PromoCodeId
		};
	}
}
