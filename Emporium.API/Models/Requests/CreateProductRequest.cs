using System.ComponentModel.DataAnnotations;

namespace Emporium.API.Models.Requests
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
