using WebApi.Helpers.Repositories;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class OrderService
{
	private readonly OrderReviewRepository _orderReviewRepository;

	public OrderService(OrderReviewRepository orderReviewRepository)
	{
		_orderReviewRepository = orderReviewRepository;
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
