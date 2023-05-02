using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Color { get; set; }

        public string ImageUrl { get; set; }

        public int? TagId { get; set; }
        public TagDTO Tag { get; set; }

        public int? Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
