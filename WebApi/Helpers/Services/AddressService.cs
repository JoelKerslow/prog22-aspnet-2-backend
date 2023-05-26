using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepo;

    public AddressService(AddressRepository repo)
    {
        _addressRepo = repo;
    }

    public async Task<IEnumerable<AddressDto>> GetAllByUserIdAsync(int userId)
    {
        var entityList = await _addressRepo.GetAllByUserIdAsync(userId);
        var addressList = new List<AddressDto>();
        foreach (var address in entityList)
        {
            AddressDto dto = address;
            if (dto != null)
                addressList.Add(dto);
        }
        return addressList;
    } 

    public async Task<bool> UpdateCustomerAddressAsync(AddressUpdateSchema schema)
    {
        var adress = await _addressRepo.GetAsync(x => x.CustomerProfileId == schema.CustomerProfileId);
        if (adress != null)
        {
            try
            {
                AddressEntity updatedAddress = schema;
                await _addressRepo.UpdateAsync(updatedAddress);
                return true;
            }
            catch (Exception) {}
        }

        return false;
    }

    public async Task<AddressEntity> AddAsync(AddressSchema schema)
    {
        return await _addressRepo.AddAsync(schema);
    }
}
