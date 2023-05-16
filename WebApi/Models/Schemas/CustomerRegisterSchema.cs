using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas;

public class CustomerRegisterSchema
{
	[Required]
	public string FirstName { get; set; } = null!;

	[Required]
	public string LastName { get; set; } = null!;

	[Required]
	public string Email { get; set; } = null!;

	[Required]
	public string Password { get; set; } = null!;


	public static implicit operator CustomerProfileEntity(CustomerRegisterSchema schema)
	{
		return new CustomerProfileEntity
		{
			FirstName = schema.FirstName,
			LastName = schema.LastName,
			Email = schema.Email,
		};
	}

	public static implicit operator IdentityUser(CustomerRegisterSchema schema)
	{
		return new IdentityUser
		{
			Email = schema.Email,
			UserName = schema.Email
		};
	}
}

