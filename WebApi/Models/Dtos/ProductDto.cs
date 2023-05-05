namespace WebApi.Models.Dtos;

public class ProductDto
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string Description { get; set; } = null!;

	public string Brand { get; set; } = null!;

	public decimal Price { get; set; }

	public string? Color { get; set; }

	public string? ImageUrl { get; set; }

	public int Stock { get; set; }

	public string Category { get; set; } = null!;
	public string Department { get; set; } = null!;
	public string Tag { get; set; } = null!;
	public int ReviewAverage { get; set; }
}
