using SalesManager.Core.Entities;

namespace SalesManager.Core.Models
{
    public record class OrderDTO(
        int Id,
        string Name,
        string State,
        int StateId,
        WindowDTO[] Windows
        );
}
