using WebApi.Helpers.Repositories;
using WebApi.Models;
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

	public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync());
	}

	public async Task<IEnumerable<Size>> GetAllSizesAsync()
	{
		return await _productRepo.GetAllSizesAsync();
	}

	public async Task<IEnumerable<ProductDto>> SearchAsync(string searchValue)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.Name.Contains(searchValue) || x.Description.Contains(searchValue)));
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

	public async Task<ProductDto> GetProductByIdAsync(int productId)
	{
		return ConvertEntities(await _productRepo.GetAsync(x => x.Id == productId));
	}

	public async Task<IEnumerable<ProductDto>> GetByNewestDateAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync()).OrderByDescending(x => x.CreatedAt);
	}

	public async Task<IEnumerable<ProductDto>> GetByOldestDateAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync()).OrderBy(x => x.CreatedAt);
	}

	public async Task<IEnumerable<ProductDto>> GetByHighestPriceAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync()).OrderByDescending(x => x.Price);
	}

	public async Task<IEnumerable<ProductDto>> GetByLowestPriceAsync()
	{
		return ConvertEntities(await _productRepo.GetAllAsync()).OrderBy(x => x.Price);
	}

	public async Task<IEnumerable<ProductDto>> GetByPriceAsync(int amount)
	{
		return ConvertEntities(await _productRepo.GetAllAsync(x => x.Price <= amount));
	}

	public async Task<IEnumerable<ProductDto>> GetByColorAsync(string color)
	{
		if (!Enum.TryParse<Color>(color, true, out var colorEnum))
		{
			throw new ArgumentException($"Invalid color value: {color}");
		}

		return ConvertEntities(await _productRepo.GetAllAsync(x => x.Color == colorEnum));
	}

	public async Task<IEnumerable<ProductDto>> GetBySizeAsync(string size)
	{
		if (!Enum.TryParse<Size>(size, true, out var sizeEnum))
		{
			throw new ArgumentException($"Invalid size value: {size}");
		}

		return ConvertEntities(await _productRepo.GetAllAsync(x => x.Size == sizeEnum));
	}

	public async Task<IEnumerable<ProductDto>> GetBySizeColorPriceDepartmentTagAsync(int minPrice, int maxPrice, int tagId, int departmentId, string size, string color)
	{
		if (!Enum.TryParse<Size>(size, true, out var sizeEnum) || !Enum.TryParse<Color>(color, true, out var colorEnum))
		{
			throw new ArgumentException($"Invalid value: {size} or {color}");
		}

		return ConvertEntities(await _productRepo.GetAllAsync((x => x.Size == sizeEnum && x.Color == colorEnum && x.Price >= minPrice 
		&& x.Price <= maxPrice && x.TagId == tagId && x.DepartmentId == departmentId)));
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
		if (entity.Reviews.Count > 0)
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