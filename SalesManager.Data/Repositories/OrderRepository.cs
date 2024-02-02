using Microsoft.EntityFrameworkCore;
using SalesManager.Core.Entities;
using SalesManager.Core.Interfaces;
using SalesManager.Core.Specs;

namespace SalesManager.Data.Repositories
{
	public class OrderRepository(SalesDataContext context) : IRepository<Order>
    {
        private readonly SalesDataContext _context = context;

        public async Task AddAsync(Order entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Order?> FindAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(QueryFilter<Order> filter)
        {
            return await _context.Orders
                    .Where(filter.Query == null ? _ => true : filter.Query)
                    .Include(x => x.State)
                    .Include(x => x.Windows)
                    .ThenInclude(x => x.SubElements)
                    .Skip(filter.Offset)
                    .Take(filter.PageSize)
                    .ToListAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
