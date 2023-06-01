using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllByUserIdAsync(int userId);
        Task<bool> UpdateCustomerAddressAsync(AddressUpdateSchema schema);
        Task<AddressEntity> AddAsync(AddressSchema schema);

    }
}
