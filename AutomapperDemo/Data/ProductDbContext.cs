﻿using AutomapperDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomapperDemo.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

        // Configuring the model and seeding data using HasData method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding initial Product records into the database
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "High-end gaming laptop",
                    Price = 1500.99m,
                    IsAvailable = true,
                    Category = "Electronics",
                    SupplierCost = 1200.00m,  // Internal/sensitive info
                    SupplierInfo = "Tech Supplier Co.",
                    StockQuantity = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "Latest model with advanced features",
                    Price = 999.99m,
                    IsAvailable = true,
                    Category = "Electronics",
                    SupplierCost = 750.00m,  // Internal/sensitive info
                    SupplierInfo = "Mobile Solutions Inc.",
                    StockQuantity = 100
                },
                new Product
                {
                    Id = 3,
                    Name = "Desk Chair",
                    Description = "Ergonomic office chair",
                    Price = 299.99m,
                    IsAvailable = true,
                    Category = "Furniture",
                    SupplierCost = 200.00m,  // Internal/sensitive info
                    SupplierInfo = "Furniture Plus Ltd.",
                    StockQuantity = 25
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}