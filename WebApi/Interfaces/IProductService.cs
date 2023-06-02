using WebApi.Models;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface IProductService
    {
        Task<ProductEntity> CreateAsync(ProductSchema schema);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<IEnumerable<Size>> GetAllSizesAsync();
        Task<IEnumerable<ProductDto>> GetByCategoryAndDepartmentAsync(int categoryId, int departmentId);
        Task<IEnumerable<ProductDto>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductDto>> GetByColorAsync(string color);
        Task<IEnumerable<ProductDto>> GetByDepartmentAsync(int departmentId);
        Task<IEnumerable<ProductDto>> GetByHighestPriceAsync();
        Task<IEnumerable<ProductDto>> GetByLowestPriceAsync();
        Task<IEnumerable<ProductDto>> GetByNewestDateAsync();
        Task<IEnumerable<ProductDto>> GetByOldestDateAsync();
        Task<IEnumerable<ProductDto>> GetByPriceAsync(int amount);
        Task<IEnumerable<ProductDto>> GetBySizeAsync(string size);
        Task<IEnumerable<ProductDto>> GetBySizeColorPriceDepartmentTagAsync(int minPrice, int maxPrice, int tagId, int departmentId, string size, string color);
        Task<IEnumerable<ProductDto>> GetByTagAsync(int tagId);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> SearchAsync(string searchValue);
    }
}