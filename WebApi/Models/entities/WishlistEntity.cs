using System.ComponentModel.DataAnnotations;
using WebApi.Models.entities;

namespace WebApi.Models.Entities;

public class WishlistEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int CustomerProfileId { get; set; }
	public CustomerProfileEntity CustomerProfile { get; set; } = null!;

	public ICollection<WishlistItemEntity> WishlistItems { get; set; } = new HashSet<WishlistItemEntity>();
}

