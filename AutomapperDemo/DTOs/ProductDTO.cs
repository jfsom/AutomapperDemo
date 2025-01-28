using System.ComponentModel.DataAnnotations;
namespace AutomapperDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Category { get; set; }
        // Note: Excluding SupplierCost, SupplierInfo, and StockQuantity for security reasons
    }
}