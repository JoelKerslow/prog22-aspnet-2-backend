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

	private IEnumerable<ProductDto> ConvertEntities(IEnumerable<ProductEntity> entities)
	{
		var products = new List<ProductDto>();

		foreach (var item in entities)
		{
			ProductDto dto = item;
			dto.Category = item.Category.CategoryName;
			dto.Department = item.Department.Name;
			dto.Tag = item.Tag.Name;

			products.Add(dto);
		}

		return products;
	}
}
