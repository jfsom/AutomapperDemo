using System.ComponentModel.DataAnnotations;
namespace AutomapperDemo.DTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
        public string Category { get; set; }

        // Sensitive internal fields
        public decimal SupplierCost { get; set; } // Admin-provided internal cost
        public string SupplierInfo { get; set; } // Supplier details
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } // Initial stock
    }
}