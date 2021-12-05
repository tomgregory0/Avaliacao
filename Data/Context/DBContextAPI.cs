using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Context
{
    public class DBContextAPI : DbContext
    {
        public DBContextAPI(DbContextOptions<DBContextAPI> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new InventoryMapping());
            //modelBuilder.ApplyConfiguration(new ProductMapping());
            //modelBuilder.ApplyConfiguration(new WareHouseMapping());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContextAPI).Assembly);

            var product = new Product
            {
                Id = 1,
                SKU = 43264,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g"
            };

            modelBuilder.Entity<Product>().HasData
            (
                product
            );

            Inventory inventory = new Inventory() { Id = 1, ProductSKU = 43264L, ProductId = 1 };

            modelBuilder.Entity<Inventory>().HasData
           (
               inventory
           );

            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses.Add(new Warehouse()
            {
                Id = 2,
                Locality = "SP",
                Quantity = 12,
                InventoryId = inventory.Id,
                Type = "ECOMMERCE"
            });
            warehouses.Add(new Warehouse()
            {
                Id = 1,
                Locality = "MOEMA",
                Quantity = 8,
                InventoryId = inventory.Id,
                Type = "PHYSICAL_STORE"

            });

            modelBuilder.Entity<Warehouse>().HasData
            (
                warehouses.ToArray()
            );

        }

    }
}
