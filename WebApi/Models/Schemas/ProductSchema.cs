using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class ProductSchema
{
	[Required]
	public string Name { get; set; } = null!;

	[Required]
	public string Description { get; set; } = null!;

	[Required]
	public string Brand { get; set; } = null!;

	[Required]
	public decimal Price { get; set; }

	public string? Color { get; set; }

	public string? ImageUrl { get; set; }

	[Required]
	public int Stock { get; set; }

	[Required]
	public string Category { get; set; } = null!;

	[Required]
	public string Department { get; set; } = null!;

	[Required]
	public string Tag { get; set; } = null!;


	public static implicit operator ProductEntity(ProductSchema schema)
	{
		return new ProductEntity
		{
			Name = schema.Name,
			Description = schema.Description,
			Brand = schema.Brand,
			Price = schema.Price,
			Color = schema.Color,
			ImageUrl = schema.ImageUrl,
			Stock = schema.Stock,
		};
	}
}
