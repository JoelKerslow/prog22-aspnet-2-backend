using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities
{
	public class ProductEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;

		[Required]
		public string Brand { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		public Color? Color { get; set; }

		public Size? Size { get; set; }

		public string? ImageUrl { get; set; }

		[Required]
		public int Stock { get; set; }

		[Required]
		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; } = null!;

		[Required]
		public int DepartmentId { get; set; }
		public DepartmentEntity Department { get; set; } = null!;

		[Required]
		public int TagId { get; set; }
		public TagEntity Tag { get; set; } = null!;

		public int? CampaignId { get; set; }
		public CampaignEntity? Campaign { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? ModifiedAt { get; set; }


		public ICollection<ProductReviewEntity> Reviews { get; set; } = new HashSet<ProductReviewEntity>();


		public static implicit operator ProductDto(ProductEntity entity)
		{
			return new ProductDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				Brand = entity.Brand,
				Price = entity.Price,
				Color = entity.Color,
				Size = entity.Size,
				ImageUrl = entity.ImageUrl,
				Stock = entity.Stock,
				CreatedAt = entity.CreatedAt
			};
		}

		public static implicit operator ProductEntity(ProductDto dto)
		{
			return new ProductEntity
			{
				Id = dto.Id,
				Name = dto.Name,
				Description = dto.Description,
				Brand = dto.Brand,
				Price = dto.Price,
				Color = dto.Color,
				Size = dto.Size,
				ImageUrl = dto.ImageUrl,
				Stock = dto.Stock,
				CreatedAt = dto.CreatedAt,
			};
		}
	}
}
