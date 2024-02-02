using Microsoft.EntityFrameworkCore;
using SalesManager.Core.Entities;
using SalesManager.Core.Interfaces;
using SalesManager.Core.Specs;

namespace SalesManager.Data.Repositories
{
    public class WindowRepository : IRepository<Window>
    {
        private readonly SalesDataContext _context;

        public WindowRepository(SalesDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Window entity)
        {
            _context.Windows.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Windows
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Window?> FindAsync(int id)
        {
            return await _context.Windows.FindAsync(id);
        }

        public async Task<IEnumerable<Window>> GetAllAsync(QueryFilter<Window> filter)
        {
            return await _context.Windows
                    .Where(filter.Query == null ? _ => true : filter.Query)
                    .Include(x => x.SubElements)
                    .Skip(filter.Offset)
                    .Take(filter.PageSize)
                    .ToListAsync();
        }

        public async Task UpdateAsync(Window entity)
        {
            _context.Windows.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
