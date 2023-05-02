using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ProductReviewEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public CustomerProfileEntity Customer { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }=null!;
    }
}
