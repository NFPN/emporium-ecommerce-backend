namespace Emporium.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public required ICollection<Address> Addresses { get; set; }

        public required ShoppingCart ShoppingCart { get; set; }
    }
}
