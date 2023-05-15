using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class OrderReviewRepository : Repository<OrderReviewEntity>
{
	public OrderReviewRepository(DataContext context) : base(context)
	{
	}
}
