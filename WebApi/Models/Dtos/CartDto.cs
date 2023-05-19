using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class CartDto
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public PromoCodeEntity? PromoCode { get; set; }
		public int? PromoCodeId { get; set; }
		public bool IsActive { get; set; }
		public decimal TotalPrice { get; set; }
		public ICollection<CartItemEntity> CartItems { get; set; } = new HashSet<CartItemEntity>();

		public static implicit operator CartDto(CartEntity entity)
		{
			return new CartDto
			{
				Id = entity.Id,
				CustomerId = entity.CustomerProfileId,
				PromoCodeId = entity.PromoCodeId,
				PromoCode = entity.PromoCode,
				IsActive = entity.IsActive,
				TotalPrice = entity.TotalPrice,
				CartItems = entity.CartItems
			};
		}

		public static implicit operator CartEntity(CartDto dto)
		{
			return new CartDto
			{
				Id = dto.Id,
				CustomerId = dto.CustomerId,
				PromoCodeId = dto.PromoCodeId,
				PromoCode = dto.PromoCode,
				IsActive = dto.IsActive,
				TotalPrice = dto.TotalPrice,
				CartItems = dto.CartItems
			};

		}
	}
}
