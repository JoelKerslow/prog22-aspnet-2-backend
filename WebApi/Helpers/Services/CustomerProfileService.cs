using WebApi.Helpers.Repositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class CustomerProfileService
{
	private readonly CustomerProfileRepository _customerProfileRepository;

	public CustomerProfileService(CustomerProfileRepository customerProfileRepository)
	{
		_customerProfileRepository = customerProfileRepository;
	}

	public async Task<CustomerProfileEntity> CreateAsync(CustomerProfileEntity entity, string userId)
	{
		entity.UserId = userId;
		return await _customerProfileRepository.AddAsync(entity);
	}
}
