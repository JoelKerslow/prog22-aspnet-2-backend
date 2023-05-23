using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class OrderRepository : Repository<OrderEntity>
{
	private readonly DataContext _context;
	public OrderRepository(DataContext context) : base(context)
	{
		_context = context;
	}

	public override async Task<IEnumerable<OrderEntity>> GetAllAsync(Expression<Func<OrderEntity, bool>> predicate)
	{
		return await _context.Orders.Where(predicate).Include(x => x.OrderDetails).ThenInclude(x => x.Product).ToListAsync();
	}
}
