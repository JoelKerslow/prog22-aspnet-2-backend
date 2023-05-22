
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class PromoCodeRepository : Repository<PromoCodeEntity>
	{
		private readonly DataContext _context;

		public PromoCodeRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public async Task<PromoCodeEntity?> FindByIdAsync(int promoCodeId)
		{
			return await _context.PromoCodes.FindAsync(promoCodeId);
		}
	}
}
