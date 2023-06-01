using WebApi.Models.Dtos;
using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface IProductReviewService
    {
        Task<bool> CreateReviewAsync(ProductReviewSchema schema);
        Task<ICollection<ProductReviewDto>> GetAllAsync(int ProductId);
    }
}
