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
        var address = await _addressRepo.GetAsync(x => x.Id == schema.Id);
        if (address != null)
        {
            try
            {
                address.Title = schema.Title;
                address.Addressline1 = schema.Addressline1;
                address.Addressline2 = schema.Addressline2;
                address.PostalCode = schema.PostalCode;
                address.Country = schema.Country;
                address.City = schema.City;
                address.Icon = schema.Icon;
                await _addressRepo.UpdateAsync(address);
                return true;
            }
            catch (Exception) { }
        }

        return false;
    }

    public async Task<AddressEntity> AddAsync(AddressSchema schema)
    {
        return await _addressRepo.AddAsync(schema);
    }
}
