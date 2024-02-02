namespace SalesManager.Core.Entities
{
	public class OrderWindow : EntityBase
    {
        public int OrderId { get; set; }

        public int WindowId { get; set; }

        public Order Order { get; set; } = null!;

        public Window Window { get; set; } = null!;
    }
}
