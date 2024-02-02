using SalesManager.Core.Models;
using System.Linq.Expressions;

namespace SalesManager.Core.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrdersAsync(int page=1, int pageSize=10);

        Task<OrderDTO?> GetOrderByIdAsync(int id);

        Task AddOrderAsync(OrderDTO order);
    }
}
