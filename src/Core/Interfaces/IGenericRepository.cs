using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellation);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task AddAsync(T entity, CancellationToken cancellation);
        Task UpdateAsync(T entity, CancellationToken cancellation);
        Task DeleteAsync(T entity, CancellationToken cancellation);
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> ListByConditionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
