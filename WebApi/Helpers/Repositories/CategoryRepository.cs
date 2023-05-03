using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class CategoryRepository : Repository<CategoryEntity>
{
	public CategoryRepository(DataContext context) : base(context)
	{
	}
}
