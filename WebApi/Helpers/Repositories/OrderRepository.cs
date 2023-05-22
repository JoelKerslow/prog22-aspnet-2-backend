using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class OrderRepository : Repository<OrderEntity>
{
	public OrderRepository(DataContext context) : base(context)
	{
	}
}
