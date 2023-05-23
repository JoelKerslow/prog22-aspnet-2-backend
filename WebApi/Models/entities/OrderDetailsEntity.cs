using Microsoft.EntityFrameworkCore;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Models.entities;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class OrderDetailsEntity
{
	public int OrderId { get; set; }
	public OrderEntity Order { get; set; } = null!;
	public int ProductId { get; set; }
	public ProductEntity Product { get; set; } = null!;
	public int Quantity { get; set; }

	public static implicit operator OrderDetailsDto(OrderDetailsEntity entity)
	{
		return new OrderDetailsDto
		{
			Quantity = entity.Quantity,
			Product = entity.Product,
		};
	}
}
