using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
	public decimal TotalAmountWithoutDiscount => CartItems.Sum(x => x.Quantity * x.Product.Price);

	[NotMapped]
	public decimal DiscountAmount => PromoCode is null ? 0 : TotalAmountWithoutDiscount * PromoCode.Discount / 100;

	[NotMapped]
	public decimal TotalAmountWithDiscount => TotalAmountWithoutDiscount - DiscountAmount;

	public ICollection<CartItemEntity> CartItems { get; set; } = new List<CartItemEntity>();
}

