using SalesManager.Core.Entities;
using SalesManager.Core.Models;

namespace SalesManager.Core.Interfaces
{
    public interface IWindowService
    {
        Task<WindowDTO?> FindAsync(int id);

        Task AddAsync(WindowDTO window);

        Task<IEnumerable<WindowDTO>> GetAllAsync(int page, int pageSize);
    }
}
