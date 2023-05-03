using WebApi.Helpers.Repositories;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;
	private readonly CategoryRepository _categoryRepo;
	private readonly DepartmentRepository _departmentRepo;
	private readonly TagRepository _tagRepo;

	public ProductService(ProductRepository productRepo, CategoryRepository categoryRepo, DepartmentRepository departmentRepo, TagRepository tagRepo)
	{
		_productRepo = productRepo;
		_categoryRepo = categoryRepo;
		_departmentRepo = departmentRepo;
		_tagRepo = tagRepo;
	}

	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
		var items = await _productRepo.GetAllAsync();
		var products = new List<ProductDto>();

		foreach (var item in items)
		{
			ProductDto dto = item;
			dto.Category = item.Category.CategoryName;
			dto.Department = item.Department.Name;
			dto.Tag = item.Tag.Name;

			products.Add(dto);
		}

		return products;
	}

	public async Task<ProductEntity> CreateAsync(ProductSchema schema)
	{
		return await _productRepo.AddAsync(schema);
	}
}
