using SalesManager.Core.Entities;
using SalesManager.Core.Specs;

namespace SalesManager.Core.Interfaces
{
	public interface IRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync(QueryFilter<T> filter);

        Task AddAsync(T entity);

        Task DeleteAsync(int id);

        Task UpdateAsync(T entity);

        Task<T?> FindAsync(int id);
    }
}
