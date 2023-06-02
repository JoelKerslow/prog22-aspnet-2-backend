using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Interfaces;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class ShowcaseRepository : Repository<ShowcaseEntity>, IShowcaseRepository
	{
		private readonly DataContext _context;
		public ShowcaseRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public override async Task<IEnumerable<ShowcaseEntity>> GetAllAsync()
		{
			return await _context.Showcases.ToListAsync();
		}
	}
}
