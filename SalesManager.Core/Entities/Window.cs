using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManager.Core.Entities
{
	public class Window : EntityBase
    {
        [Required]
        public string Name { get; set; } = null!;

        public int TotalSubElements { get; set; }

        public int QuantityOfWindows { get; set; }

        public virtual Collection<SubElement> SubElements { get; set; } = null!;
    }
}
