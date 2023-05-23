﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models.Entities;

public class CartEntity
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int CustomerProfileId { get; set; }
	public CustomerProfileEntity CustomerProfile { get; set; } = null!;

	public int? PromoCodeId { get; set; }
	public PromoCodeEntity? PromoCode { get; set; }

	[Required]
	public DateTime CreatedAt { get; set; }

	[Required]
	public bool IsActive { get; set; }

	[NotMapped]
	public decimal TotalPrice { get; set; }

	[JsonIgnore]
	public ICollection<CartItemEntity> CartItems { get; set; } = new HashSet<CartItemEntity>();
}

