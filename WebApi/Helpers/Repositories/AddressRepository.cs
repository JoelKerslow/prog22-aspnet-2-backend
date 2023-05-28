using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Helpers.Repositories.BaseRepositories;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        private readonly DataContext _context;
        public AddressRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressEntity>> GetAllByUserIdAsync(int userID)
        {
            return await _context.Addresses.Where(x => x.CustomerProfileId == userID).ToListAsync();
        }
    }
}
