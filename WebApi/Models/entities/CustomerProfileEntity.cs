using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CustomerProfileEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string FirstName { get; set; } = null!;

	[Required]
	public string LastName { get; set; } = null!;

	[Required]
	public string Email { get; set; } = null!;

	public string? ProfileImageUrl { get; set; }

	[Required]
	public string UserId { get; set; } = null!;

	public ICollection<AddressEntity> Addresses { get; set; } = new HashSet<AddressEntity>();

	public ICollection<PromoCodeEntity> PromoCodes { get; set; } = new HashSet<PromoCodeEntity>();


}
