using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class WishlistEntity
{
	[Key]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public CustomerProfileEntity Customer { get; set; } = null!;
}
