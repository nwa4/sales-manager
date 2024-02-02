namespace SalesManager.Core.Models
{
    public record WindowDTO(
        int Id,
        string Name,
        int TotalSubElements,
        int QuantityOfWindows,
        SubElementDTO[] SubElements
        );
}