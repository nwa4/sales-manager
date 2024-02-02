namespace SalesManager.Core.Entities
{
    public class SubElement : EntityBase
    {
        public int Element { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int TypeId { get; set; }

        public SubElementType Type { get; set; } = null!;

        public int WindowId { get; set; }

        public Window Window { get; set; } = null!;
    }
}
