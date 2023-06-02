using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface ICustomerProfileService
    {
        Task<CustomerProfileEntity> CreateAsync(CustomerProfileEntity entity, string userId);
        Task<CustomerProfileDto> GetCustomerProfile(string token);
        Task<bool> UpdateCustomerProfileAsync(CustomerUpdateSchema schema);
    }
}