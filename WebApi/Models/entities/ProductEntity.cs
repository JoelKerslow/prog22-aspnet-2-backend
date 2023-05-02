using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public string? Color { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

        [Required]
        public int DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; } = null!;

        [Required]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; } = null!;

        public int? CampaignId { get; set; }
        public CampaignEntity? Campaign { get; set; }


        public IEnumerable<ProductReviewEntity> Reviews { get; set; } = new List<ProductReviewEntity>();

    }
}
