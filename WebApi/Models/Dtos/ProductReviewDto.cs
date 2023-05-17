using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string? ImageUrl { get; set; }

		public DateTime CreatedDate { get; set; }

	}
}
