using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellation);
        Task AddAsync(T entity, CancellationToken cancellation);
        Task UpdateAsync(T entity, CancellationToken cancellation);
        Task DeleteAsync(T entity, CancellationToken cancellation);
    }
}
