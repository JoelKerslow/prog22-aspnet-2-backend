using WebApi.Models.Dtos;

namespace WebApi.Interfaces
{
    public interface IShowcaseService
    {
        Task<IEnumerable<ShowcaseDto>> GetAllAsync();
    }
}