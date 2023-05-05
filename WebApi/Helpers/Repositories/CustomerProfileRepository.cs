using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class CustomerProfileRepository : Repository<CustomerProfileEntity>
{
	public CustomerProfileRepository(DataContext context) : base(context)
	{
	}
}
