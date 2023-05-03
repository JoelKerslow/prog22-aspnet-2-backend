using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	private readonly DataContext _context;

	public ProductRepository(DataContext context) : base(context)
	{
		_context = context;
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _context.Products.Include("Tag").Include("Category").Include("Department").ToListAsync();
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		return await _context.Products.Include("Tag").Include("Category").Include("Department").Where(predicate).ToListAsync();
	}
}
