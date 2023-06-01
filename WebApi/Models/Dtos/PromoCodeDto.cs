using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class PromoCodeDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public string? Brand { get; set; }
        public int Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Code { get; set; } = null!;
        public bool IsReusable { get; set; }
        public bool IsValid { get; set; }

        public static implicit operator PromoCodeEntity(PromoCodeDto dto)
        {
            return new PromoCodeEntity
            {
                Id = dto.Id,
                Description = dto.Description,
                Brand = dto.Brand,
                Discount = dto.Discount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Code = dto.Code,
                IsReusable = dto.IsReusable,
                IsValid = dto.IsValid
            };
        }
    }
}
