using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Contexts;

namespace WebApi.Helpers.Repositories.BaseRepositories
{
	public abstract class Repository<TEntity> where TEntity : class
	{
		readonly DataContext _context;

		public Repository(DataContext context)
		{
			_context = context;
		}

		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);

			if (entity != null)
				return entity;

			return null!;
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().Where(predicate).ToListAsync();
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public virtual async Task<TEntity> UpdateByIdAsync(int id, TEntity entity)
		{
			TEntity? local = await _context.Set<TEntity>().FindAsync(id);
			if (local is not null) _context.Entry(local).State = EntityState.Detached;

			_context.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();

			return entity;
		}

		public virtual async Task RemoveAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
