namespace Emporium.Application.DTO
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Description { get; set; }
    }
}
