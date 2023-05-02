﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
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
	public int AddressId { get; set; }
	public AddressEntity Address { get; set; } = null!;

	[Required]
	public int ShippingAddressId { get; set; }
	public AddressEntity ShippingAddress { get; set; } = null!;

	[Required]
	public int UserId { get; set; }
	public IdentityUser User { get; set; } = null!;

	[Required]
	public int FavouritesId { get; set; }
	public FavouritesEntity Favourites { get; set; } = null!;

	[Required]
	public int CartId { get; set; }
	public CartEntity Cart { get; set; } = null!;


	public IEnumerable<PromoCodeEntity> PromoCodes { get; set; } = new List<PromoCodeEntity>();


}
