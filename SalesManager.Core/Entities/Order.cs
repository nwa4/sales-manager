using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManager.Core.Entities
{
	public class Order : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public int StateId { get; set; }

        public State State { get; set; } = null!;

        public virtual Collection<Window> Windows { get; set; } = null!;

    }
}
