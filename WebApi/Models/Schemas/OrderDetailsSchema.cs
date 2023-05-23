using System.ComponentModel.DataAnnotations;
using WebApi.Models.entities;

namespace WebApi.Models.Schemas;

public class OrderDetailsSchema
{
	[Required]
	public int ProductId { get; set; }

	[Required]
	public int Quantity { get; set; }

	public static implicit operator OrderDetailsEntity(OrderDetailsSchema schema)
	{
		return new OrderDetailsEntity
		{
			ProductId = schema.ProductId,
			Quantity = schema.Quantity
		};
	}
}
