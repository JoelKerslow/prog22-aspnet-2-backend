using WebApi.Models.Entities;

namespace WebApi.Models.Dtos;

public class OrderDetailsDto
{
	public ProductEntity Product { get; set; } = null!;

	public int Quantity { get; set; }
}
