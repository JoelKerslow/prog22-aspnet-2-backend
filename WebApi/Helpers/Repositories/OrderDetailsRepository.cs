using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.entities;

namespace WebApi.Helpers.Repositories;

public class OrderDetailsRepository : Repository<OrderDetailsEntity>
{
	public OrderDetailsRepository(DataContext context) : base(context)
	{
	}
}
