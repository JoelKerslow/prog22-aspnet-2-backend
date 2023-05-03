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
		ProductEntity entity = schema;
		entity.Category = await _categoryRepo.GetAsync(x => x.CategoryName == schema.Category);
		entity.Department = await _departmentRepo.GetAsync(x => x.Name == schema.Department);
		entity.Tag = await _tagRepo.GetAsync(x => x.Name == schema.Tag);

		return await _productRepo.AddAsync(entity);
	}
}
