using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class CampaignProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsDiscountPercent { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }

        
    }
}
