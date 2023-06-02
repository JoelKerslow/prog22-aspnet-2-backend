using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
	private readonly DataContext _context;

	public ProductRepository(DataContext context) : base(context)
	{
		_context = context;
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _context.Products.Include("Tag").Include("Category").Include("Department").Include("Reviews").ToListAsync();
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		return await _context.Products.Include("Tag").Include("Category").Include("Department").Include("Reviews").Where(predicate).ToListAsync();
	}

	public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		var entity = await _context.Products.Include("Tag").Include("Category").Include("Department").Include("Reviews").FirstOrDefaultAsync(predicate);

		if (entity != null)
			return entity;

		return null!;
	}

	public async Task<IEnumerable<Size>> GetAllSizesAsync()
	{
		return await Task.Run(() => Enum.GetValues(typeof(Size)).Cast<Size>());
	}
}
