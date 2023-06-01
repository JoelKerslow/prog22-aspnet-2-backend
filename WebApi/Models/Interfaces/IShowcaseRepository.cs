using WebApi.Models.Entities;

namespace WebApi.Models.Interfaces
{
    public interface IShowcaseRepository
    {
        Task<IEnumerable<ShowcaseEntity>> GetAllAsync();
    }
}