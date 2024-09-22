namespace Emporium.Domain.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
