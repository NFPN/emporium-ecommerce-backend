namespace Emporium.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int StockQuantity { get; set; }

        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
