using WebApi.Models.Entities;

namespace WebApi.Interfaces
{
    public interface IShowcaseRepository
    {
        Task<IEnumerable<ShowcaseEntity>> GetAllAsync();
    }
}