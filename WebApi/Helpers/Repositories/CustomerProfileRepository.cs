using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Helpers.Repositories.Interfaces;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class CustomerProfileRepository : Repository<CustomerProfileEntity>, ICustomerProfileRepository
{
	public CustomerProfileRepository(DataContext context) : base(context)
	{
	}
}
