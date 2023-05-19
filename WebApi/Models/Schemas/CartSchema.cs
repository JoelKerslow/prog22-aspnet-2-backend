using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
	public class CartSchema
	{
		public int CustomerProfileId { get; set; }

		public int? PromoCodeId { get; set; }

		[Required]
		public bool IsActive { get; set; }


		public static implicit operator CartEntity(CartSchema schema)
		{
			return new CartEntity
			{
				CustomerProfileId = schema.CustomerProfileId,
				PromoCodeId = schema.PromoCodeId,
				IsActive = schema.IsActive
			};
		}
	}
}
