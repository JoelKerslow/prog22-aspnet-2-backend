using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ProductReviewEntity
    {
        [Key]
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }=null!;

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerProfileEntity Customer { get; set; }=null!;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }=null!;
    }
}
