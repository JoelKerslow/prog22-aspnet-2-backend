﻿using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
	public class CartItemSchema
	{
		[Required]
		public int ProductId { get; set; }


		public static implicit operator CartItemEntity(CartItemSchema schema)
		{
			return new CartItemEntity
			{
				ProductId = schema.ProductId,
			};
		}
	}
}
