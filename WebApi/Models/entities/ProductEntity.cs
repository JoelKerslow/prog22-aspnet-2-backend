using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Color { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryEntity Category { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public DepartmentEntity Department { get; set; }

        [Required]
        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public TagEntity Tag { get; set; }

       

    }
}
