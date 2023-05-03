﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CartEntity
{
	[Key]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public CustomerProfileEntity Customer { get; set; } = null!;
	public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
