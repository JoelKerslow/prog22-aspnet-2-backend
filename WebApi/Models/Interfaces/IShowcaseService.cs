using WebApi.Models.Dtos;

namespace WebApi.Models.Interfaces
{
    public interface IShowcaseService
    {
        Task<IEnumerable<ShowcaseDto>> GetAllAsync();
    }
}