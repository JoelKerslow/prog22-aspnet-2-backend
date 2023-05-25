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
		public decimal TotalAmountWithoutDiscount { get; set; }
		public decimal DiscountAmount { get; set; }
		public decimal TotalAmountWithDiscount { get; set; }
		public ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

		public static implicit operator CartDto(CartEntity entity)
		{
			return new CartDto
			{
				Id = entity.Id,
				CustomerId = entity.CustomerProfileId,
				PromoCodeId = entity.PromoCodeId,
				PromoCode = entity.PromoCode,
				IsActive = entity.IsActive,
				TotalAmountWithoutDiscount = entity.TotalAmountWithoutDiscount,
				DiscountAmount = entity.DiscountAmount,
				TotalAmountWithDiscount = entity.TotalAmountWithDiscount,
				CartItems = entity.CartItems.Select(x => (CartItemDto)x).ToList()
			};
		}

		public static implicit operator CartEntity(CartDto dto)
		{
			return new CartEntity
			{
				Id = dto.Id,
				CustomerProfileId = dto.CustomerId,
				PromoCodeId = dto.PromoCodeId,
				PromoCode = dto.PromoCode,
				IsActive = dto.IsActive,
				CartItems = dto.CartItems.Select(x => (CartItemEntity)x).ToList()
			};
		}
	}
}
