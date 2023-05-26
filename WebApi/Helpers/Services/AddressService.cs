using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;

namespace WebApi.Helpers.Services;

public class AddressService
{
    private readonly AddressRepository _repo;

    public AddressService(AddressRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<AddressDto>> GetAllByUserIdAsync(int userId)
    {
        var entityList = await _repo.GetAllByUserIdAsync(userId);
        var addressList = new List<AddressDto>();
        foreach (var address in entityList)
        {
            AddressDto dto = address;
            if (dto != null)
                addressList.Add(dto);
        }
        return addressList;
    } 
}
