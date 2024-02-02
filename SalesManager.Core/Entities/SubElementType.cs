using System.ComponentModel.DataAnnotations;

namespace SalesManager.Core.Entities
{
	public class SubElementType : EntityBase
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
