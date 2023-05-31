using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.entities;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class OrderService
{
	private readonly OrderReviewRepository _orderReviewRepository;
	private readonly OrderRepository _orderRepository;
	private readonly OrderDetailsRepository _orderDetailsRepository;
	private readonly CartService _cartService;

    public OrderService(OrderReviewRepository orderReviewRepository, OrderRepository orderRepository, OrderDetailsRepository orderDetailsRepository, CartService cartService)
    {
        _orderReviewRepository = orderReviewRepository;
        _orderRepository = orderRepository;
        _orderDetailsRepository = orderDetailsRepository;
        _cartService = cartService;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int customerId)
	{
		var orderEntities =  await _orderRepository.GetAllAsync(x => x.CustomerId== customerId);
		var orders = new List<OrderDto>();
		foreach(var entity in orderEntities) 
		{
			OrderDto order = entity;
			
			foreach(var item in entity.OrderDetails)
			{
				order.OrderDetails.Add(item);
			}

			orders.Add(order);
		}

		return orders;
	}

	public async Task<OrderDto> GetOrderByIdAsync(int orderId)
	{
		var orderEntity = await _orderRepository.GetAsync(x => x.Id == orderId);
		OrderDto order = orderEntity;

		return order;
	}


	public async Task<bool> CreateOrderAsync(OrderSchema schema, string token)
	{
		OrderEntity orderEntity = schema;
		orderEntity.OrderDate = DateTime.Now;
		orderEntity.Status = "Pending";
		orderEntity = await _orderRepository.AddAsync(orderEntity);

		if (orderEntity != null)
		{
			foreach(var item in schema.OrderDetails)
			{
				OrderDetailsEntity orderDetails = item;
				orderDetails.OrderId = orderEntity.Id;
				await _orderDetailsRepository.AddAsync(orderDetails);
			}

			await _cartService.DeleteCartItemsAsync(token);

			return true;
		}

		return false;
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
