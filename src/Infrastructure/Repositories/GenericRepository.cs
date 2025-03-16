using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellation) => await _dbSet.AddAsync(entity);

        public Task DeleteAsync(T entity, CancellationToken cancellation)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellation) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellation) => await _dbSet.ToListAsync() ?? [];

        public Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IEnumerable<T>> ListByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }
    }
}
