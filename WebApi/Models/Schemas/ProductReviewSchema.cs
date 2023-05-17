using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class ProductReviewSchema
{
	[Required]
	public int Rating { get; set; }

	public string? Comment { get; set; }

	[Required]
	public int CustomerId { get; set; }
	public int ProductId { get; set; }


	public static implicit operator ProductReviewEntity(ProductReviewSchema schema)
	{
		return new ProductReviewEntity
		{
			CustomerId = schema.CustomerId,
			ProductId = schema.ProductId,
			Rating = schema.Rating,
			Comment = schema.Comment,
			CreatedDate = DateTime.Now,
		};
	}
}
