using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories;

public class DepartmentRepository : Repository<DepartmentEntity>
{
    public DepartmentRepository(DataContext context) : base(context)
    {
    }
}
