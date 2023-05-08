using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;

	public ProductService(ProductRepository productRepo)
	{
		_productRepo = productRepo;
	}

	public async Task<ProductEntity> CreateAsync(ProductSchema schema)
	{
		return await _productRepo.AddAsync(schema);
	}

	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync());	
	}

	public async Task<IEnumerable<ProductDto>> SearchAsync(string searchVal)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.Name.ToUpper().Contains(searchVal.ToUpper())));
	}

	public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.CategoryId == categoryId));
	}

	public async Task<IEnumerable<ProductDto>> GetByDepartmentAsync(int departmentId)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.DepartmentId == departmentId));
	}

	public async Task<IEnumerable<ProductDto>> GetByCategoryAndDepartmentAsync(int categoryId, int departmentId)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.CategoryId == categoryId && x.DepartmentId == departmentId));
	}

	public async Task<IEnumerable<ProductDto>> GetByTagAsync(int tagId)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.TagId == tagId));
	}

	public async Task<ProductDto> GetByIdAsync(int productId)
	{
		return ConvertEntities(await _productRepo.GetAsync(x => x.Id == productId));
	}

	private IEnumerable<ProductDto> ConvertEntities(IEnumerable<ProductEntity> entities)
	{
		var products = new List<ProductDto>();
		
		foreach (var item in entities)
		{
			ProductDto dto = item;
			dto.Category = item.Category.CategoryName;
			dto.Department = item.Department.Name;
			dto.Tag = item.Tag.Name;
			dto.ReviewAverage = CalculateReviewAverage(item);
			dto.ReviewCount = item.Reviews.Count;

			products.Add(dto);
		}

		return products;
	}

	private ProductDto ConvertEntities(ProductEntity entity)
	{
		ProductDto dto = entity;
		dto.Category = entity.Category.CategoryName;
		dto.Department = entity.Department.Name;
		dto.Tag = entity.Tag.Name;
		dto.ReviewAverage = CalculateReviewAverage(entity);
		dto.ReviewCount = entity.Reviews.Count;

		return dto;
	}

	private int CalculateReviewAverage(ProductEntity entity)
	{
		if(entity.Reviews.Count > 0)
		{
			double reviewRatingSum = 0;
			foreach (var review in entity.Reviews)
			{
				reviewRatingSum += review.Rating;
			}
			return (int)Math.Round(reviewRatingSum / entity.Reviews.Count);
		}
		return 0;
	}
}