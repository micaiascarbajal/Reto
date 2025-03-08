using System.ComponentModel.DataAnnotations;

namespace Reto.DTOs
{
    public class ProductDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
