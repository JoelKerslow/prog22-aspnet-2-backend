using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

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
		public DateTime CreatedDate { get; set; }

		[Required]
        public int CustomerId { get; set; }
        public CustomerProfileEntity Customer { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }=null!;

        public static implicit operator ProductReviewDto(ProductReviewEntity entity)
        {
            return new ProductReviewDto
            {
                Id = entity.Id,
                Rating = entity.Rating,
                Comment = entity.Comment,
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                CustomerFirstName = entity.Customer.FirstName,
                CustomerLastName = entity.Customer.LastName,
                CreatedDate= entity.CreatedDate,
            };
        }
    }
}
