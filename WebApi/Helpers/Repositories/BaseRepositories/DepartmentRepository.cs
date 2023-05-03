using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories.BaseRepositories;

public class DepartmentRepository : Repository<DepartmentEntity>
{
	public DepartmentRepository(DataContext context) : base(context)
	{
	}
}
