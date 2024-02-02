using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManager.Core.Entities
{
	public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
