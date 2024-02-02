using System.ComponentModel.DataAnnotations;

namespace SalesManager.Core.Entities
{
	public class State : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
