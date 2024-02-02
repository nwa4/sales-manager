using SalesManager.Core.Entities;
using SalesManager.Core.Interfaces;
using SalesManager.Core.Mappings;
using SalesManager.Core.Models;
using SalesManager.Core.Specs;

namespace SalesManager.Core.Services
{
    public class OrderService(IRepository<Order> repository) : IOrderService
    {
        private readonly IRepository<Order> _repository = repository;

        public async Task AddOrderAsync(OrderDTO order)
        {
            var orderEntity = order.MapToEntity();
            await _repository.AddAsync(orderEntity);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _repository.FindAsync(id);
            return order?.MapToDTO();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync(int page = 1, int pageSize = 10)
        {
            var orders = await _repository.GetAllAsync(new QueryFilter<Order>(null!, page, pageSize));
            return orders.Select( x => x.MapToDTO() );
        }
    }
}
