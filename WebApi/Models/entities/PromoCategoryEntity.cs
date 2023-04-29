using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class PromoCategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Discount { get; set; }

        public bool? Category { get; set; }
        public bool? Supplier { get; set; } 

        [Required]
        public decimal ShopForAtLeastAmount { get; set; }

        [Required]
        public bool IsDiscountPercent { get; set; }

    }
}
