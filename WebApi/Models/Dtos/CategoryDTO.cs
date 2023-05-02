using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
    }
}
