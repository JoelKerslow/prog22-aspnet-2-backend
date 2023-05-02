using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class ProductOrderDetailEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int UnitQuantity { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }=null!;
    }
}
