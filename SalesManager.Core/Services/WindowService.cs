using SalesManager.Core.Entities;
using SalesManager.Core.Interfaces;
using SalesManager.Core.Mappings;
using SalesManager.Core.Models;
using SalesManager.Core.Specs;

namespace SalesManager.Core.Services
{
    public class WindowService(IRepository<Window> repository) : IWindowService
    {
        private readonly IRepository<Window> _repository = repository;

        public async Task AddAsync(WindowDTO window)
        {
            await _repository.AddAsync(window.MapToEntity());
        }

        public async Task<WindowDTO?> FindAsync(int id)
        {
            var window = await _repository.FindAsync(id);
            return window?.MapToDTO();
        }

        public async Task<IEnumerable<WindowDTO>> GetAllAsync(int page, int pageSize)
        {
            var windows = await _repository.GetAllAsync(new QueryFilter<Window>(null!, page, pageSize));
            return windows.Select(x => x.MapToDTO());
        }
    }
}
