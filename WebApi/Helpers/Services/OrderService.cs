using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class OrderService
{
	private readonly OrderReviewRepository _orderReviewRepository;
	private readonly OrderRepository _orderRepository;

	public OrderService(OrderReviewRepository orderReviewRepository, OrderRepository orderRepository)
	{
		_orderReviewRepository = orderReviewRepository;
		_orderRepository = orderRepository;
	}

	public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int customerId)
	{
		var entities =  await _orderRepository.GetAllAsync(x => x.CustomerId== customerId);
		var orders = new List<OrderDto>();
		foreach(var entity in entities) 
		{
			orders.Add(entity);
		}

		return orders;
	}

	public async Task<bool> CreateOrderReviewAsync(OrderReviewSchema schema)
	{
		var entity = await _orderReviewRepository.AddAsync(schema);
		if(entity == null)
		{
			return false;
		}

		return true;
	}
}
