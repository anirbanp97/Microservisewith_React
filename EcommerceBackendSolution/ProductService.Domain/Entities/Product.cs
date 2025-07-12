using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }                 // Unique ID
        public string Name { get; set; } = null!;   // Product Name
        public decimal Price { get; set; }          // Price
        public string Category { get; set; } = null!; // Grocery / Fashion / Electronics
        public string? Description { get; set; }    // Optional
        public int Stock { get; set; }              // Quantity in inventory
        public DateTime CreatedAt { get; set; }     // Record creation date
    }
}
