using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class CustomerProfileService
{
	private readonly CustomerProfileRepository _customerProfileRepository;
	private readonly JwtService _jwtService;

	public CustomerProfileService(CustomerProfileRepository customerProfileRepository, JwtService jwtService)
	{
		_customerProfileRepository = customerProfileRepository;
		_jwtService = jwtService;
	}

	public async Task<CustomerProfileEntity> CreateAsync(CustomerProfileEntity entity, string userId)
	{
		entity.UserId = userId;
		return await _customerProfileRepository.AddAsync(entity);
	}

	public async Task<CustomerProfileDto> GetCustomerProfile(string token)
	{
		var userId = _jwtService.GetIdFromToken(token);
		var customerProfileEntity = await _customerProfileRepository.GetAsync(x => x.UserId == userId);

		if(customerProfileEntity == null)
		{
			return null!;
		}
		return customerProfileEntity;
	}
}
