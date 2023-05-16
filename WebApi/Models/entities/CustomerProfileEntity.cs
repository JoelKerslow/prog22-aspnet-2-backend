using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

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

	public static implicit operator CustomerProfileDto(CustomerProfileEntity entity)
	{
		return new CustomerProfileDto
		{
			Id = entity.Id,
			FirstName = entity.FirstName,
			LastName = entity.LastName,
			Email = entity.Email,
			ProfileImageUrl = entity.ProfileImageUrl,
			UserId = entity.UserId,
		};
	}
}
