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

	public Color? Color { get; set; }

	public Size? Size { get; set; }

	public string? ImageUrl { get; set; }

	[Required]
	public int Stock { get; set; }

	[Required]
	public int CategoryId { get; set; }

	[Required]
	public int DepartmentId { get; set; }

	[Required]
	public int TagId { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime ModifiedAt { get; set; }


	public static implicit operator ProductEntity(ProductSchema schema)
	{
		return new ProductEntity
		{
			Name = schema.Name,
			Description = schema.Description,
			Brand = schema.Brand,
			Price = schema.Price,
			Color = schema.Color,
			Size = schema.Size,
			ImageUrl = schema.ImageUrl,
			Stock = schema.Stock,
			CategoryId = schema.CategoryId,
			DepartmentId = schema.DepartmentId,
			TagId = schema.TagId,
			CreatedAt = schema.CreatedAt,
			ModifiedAt = schema.ModifiedAt
		};
	}
}
