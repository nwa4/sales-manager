using SalesManager.Core.Entities;
using SalesManager.Core.Models;
using System.Collections.ObjectModel;

namespace SalesManager.Core.Mappings
{
    internal static class ModelMappings
    {
        public static OrderDTO MapToDTO(this Order order)
        {
            return new OrderDTO(
                order.Id,
                order.Name,
                order.State.Name,
                order.State.Id,
                order.Windows.Select(x => x.MapToDTO()).ToArray()
                );
        }

        public static Order MapToEntity(this OrderDTO orderDTO)
        {
            return new Order
            {
                Id = orderDTO.Id,
                Name = orderDTO.Name,
                StateId = orderDTO.StateId,
                Windows = new Collection<Window>(orderDTO.Windows.Select(x => x.MapToEntity()).ToList())
            };
        }

        public static WindowDTO MapToDTO(this Window window)
        {
            return new WindowDTO(
                window.Id,
                window.Name,
                window.TotalSubElements,
                window.QuantityOfWindows,
                window.SubElements.Select(x => x.MapToDTO()).ToArray());
        }

        public static Window MapToEntity(this WindowDTO windowDTO)
        {
            return new Window
            {
                Id = windowDTO.Id,
                Name = windowDTO.Name,
                TotalSubElements = windowDTO.TotalSubElements,
                QuantityOfWindows = windowDTO.QuantityOfWindows,
                SubElements = new Collection<SubElement>(windowDTO.SubElements.Select(x => x.MapToEntity()).ToList())
            };
        }

        public static SubElementDTO MapToDTO(this SubElement subElement)
        {
            return new SubElementDTO(subElement.Id, subElement.Height, subElement.Width, subElement.Element, subElement.TypeId, subElement.WindowId);
        }

        public static SubElement MapToEntity(this SubElementDTO subElementDTO)
        {
            return new SubElement
            {
                Id = subElementDTO.Id,
                Height = subElementDTO.Height,
                Width = subElementDTO.Width,
                Element = subElementDTO.Element,
                WindowId = subElementDTO.WindowId,
                TypeId = subElementDTO.TypeId
            };
        }
    }
}
