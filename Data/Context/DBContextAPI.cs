using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DBContextAPI : DbContext
    {
        public DBContextAPI(DbContextOptions<DBContextAPI> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouses> Warehouse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContextAPI).Assembly);


        }

    }
}
