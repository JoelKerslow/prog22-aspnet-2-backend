namespace WebApi.Models.Dtos;

public class OrderDto
{
	public int Id { get; set; }

	public int CustomerId { get; set; }

	public DateTime OrderDate { get; set; }

	public string Status { get; set; } = null!;

	public decimal TotalAmount { get; set; }

	public string? CustomerComment { get; set; }

	public int? PromoCodeId { get; set; }
}
