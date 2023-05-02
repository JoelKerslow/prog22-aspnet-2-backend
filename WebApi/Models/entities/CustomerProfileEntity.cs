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

	[Required]
	public string UserId { get; set; } = null!;

	[Required]
	public int AddressId { get; set; }
	public AddressEntity Address { get; set; } = null!;

	[Required]
	public int ShippingAddressId { get; set; }
	public AddressEntity ShippingAddress { get; set; } = null!;

	public IEnumerable<PromoCodeEntity> PromoCodes { get; set; } = new List<PromoCodeEntity>();


}
