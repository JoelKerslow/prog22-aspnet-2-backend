using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
    public class PromoCodeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

		public string? Brand { get; set; }

		[Required]
        public int Discount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Code { get; set; } = null!;

        [Required]
        public bool IsReusable { get; set; }

        [Required]
        public bool IsValid { get; set; }


        public ICollection<CustomerProfileEntity> CustomerProfiles { get; set; } = new HashSet<CustomerProfileEntity>();


        public static implicit operator PromoCodeDto(PromoCodeEntity entity)
        {
            if (entity == null) return null!;

            return new PromoCodeDto
            {
                Id = entity.Id,
                Description = entity.Description,
                Brand = entity.Brand,
                Discount = entity.Discount,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Code = entity.Code,
                IsReusable = entity.IsReusable,
                IsValid = entity.IsValid,
            };
        }
    }
}
