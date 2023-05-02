using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class WishlistEntity
{
	[Key]
	public int Id { get; set; }

	public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
