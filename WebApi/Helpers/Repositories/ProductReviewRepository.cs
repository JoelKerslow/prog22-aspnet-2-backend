using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class ProductReviewRepository : Repository<ProductReviewEntity>
{
	public ProductReviewRepository(DataContext context) : base(context)
	{
	}
}
