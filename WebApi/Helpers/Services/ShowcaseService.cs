using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;

namespace WebApi.Helpers.Services;

public class ShowcaseService
{
    private readonly ShowcaseRepository _showcaseRepo;

    public ShowcaseService(ShowcaseRepository repository)
    {
        _showcaseRepo = repository;
    }

    public async Task<IEnumerable<ShowcaseDTO>> GetAllAsync()
    {
        var showcaseList = await _showcaseRepo.GetAllAsync();
        var dtoList = new List<ShowcaseDTO>();
        foreach (var showcase in showcaseList)
        {
            ShowcaseDTO dto = showcase;
            if (dto != null)
                dtoList.Add(dto);
        }
        return dtoList;
    }
}
