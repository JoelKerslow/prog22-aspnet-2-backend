using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;

namespace WebApi.Helpers.Services;

public class ShowcaseService : IShowcaseService
{
    private readonly IShowcaseRepository _showcaseRepo;

    public ShowcaseService(IShowcaseRepository repository)
    {
        _showcaseRepo = repository;
    }

    public async Task<IEnumerable<ShowcaseDto>> GetAllAsync()
    {
        var showcaseList = await _showcaseRepo.GetAllAsync();
        var dtoList = new List<ShowcaseDto>();
        foreach (var showcase in showcaseList)
        {
            ShowcaseDto dto = showcase;
            if (dto != null)
                dtoList.Add(dto);
        }
        return dtoList;
    }
}
