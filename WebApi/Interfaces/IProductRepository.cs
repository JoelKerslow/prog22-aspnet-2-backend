using System.Linq.Expressions;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntity>
	{
		Task<IEnumerable<Size>> GetAllSizesAsync();
	}
}