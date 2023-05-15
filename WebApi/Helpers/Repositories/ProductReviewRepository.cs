using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class ProductReviewRepository : Repository<ProductReviewEntity>
{
    private readonly DataContext _context;

	public ProductReviewRepository(DataContext context) : base(context)
	{
        _context = context;
	}

    public async Task<IEnumerable<ProductReviewEntity>> GetAllAsync(int productId)
    {
        return await _context.ProductReviews.Include("Customer").Where(x => x.ProductId == productId).ToListAsync();
    }
}
