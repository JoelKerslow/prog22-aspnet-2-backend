using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class OrderReviewSchema
{
	public string? Comment { get; set; }

	[Required]
	public int Rating { get; set; }

	[Required]
	public int OrderId { get; set; }

	public static implicit operator OrderReviewEntity(OrderReviewSchema scema)
	{
		return new OrderReviewEntity
		{
			Comment = scema.Comment,
			Rating = scema.Rating,
			OrderId = scema.OrderId,
		};
	}
}
