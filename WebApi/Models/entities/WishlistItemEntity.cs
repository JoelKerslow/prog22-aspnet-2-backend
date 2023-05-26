using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Entities;

namespace WebApi.Models.entities
{
	public class WishlistItemEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int WishlistId { get; set; }
		public WishlistEntity Wishlist { get; set; } = null!;

		[Required]
		public int ProductId { get; set; }
		public ProductEntity Product { get; set; } = null!;

		[NotMapped]
		public int ReviewCount => Product.Reviews.Count;

		[NotMapped]
		public int RatingSum => Product.Reviews.Sum(x => x.Rating);
	}
}
