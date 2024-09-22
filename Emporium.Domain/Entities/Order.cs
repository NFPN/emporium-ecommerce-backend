namespace Emporium.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }

        public required ICollection<OrderItem> OrderItems { get; set; }
        public required decimal TotalAmount { get; set; }

        public Guid ShippingAddressId { get; set; }
        public Guid BillingAddressId { get; set; }
        public required Address ShippingAddress { get; set; }
        public required Address BillingAddress { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }

    // use nameof() for performance
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }
}
