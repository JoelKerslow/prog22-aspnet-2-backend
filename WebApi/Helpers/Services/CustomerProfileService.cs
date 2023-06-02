using WebApi.Helpers.Repositories;
using WebApi.Helpers.Repositories.Interfaces;
using WebApi.Interfaces;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class CustomerProfileService : ICustomerProfileService
{
	private readonly ICustomerProfileRepository _customerProfileRepository;
	private readonly JwtService _jwtService;

	public CustomerProfileService(ICustomerProfileRepository customerProfileRepository, JwtService jwtService)
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

		if (customerProfileEntity == null)
		{
			return null!;
		}
		return customerProfileEntity;
	}

	public async Task<bool> UpdateCustomerProfileAsync(CustomerUpdateSchema schema)
	{
		var customer = await _customerProfileRepository.GetAsync(x => x.Id == schema.Id);
		if (customer != null)
		{
			try
			{
				customer.FirstName = schema.FirstName;
				customer.LastName = schema.LastName;
				customer.ProfileImageUrl = schema.ProfileImageUrl;

				await _customerProfileRepository.UpdateAsync(customer);
				return true;
			}
			catch (Exception)
			{
			}
		}

		return false;
	}
}
