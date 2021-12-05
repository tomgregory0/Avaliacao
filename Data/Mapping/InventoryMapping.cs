using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    internal class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {

            builder.HasKey(o => o.Id);

            builder.HasMany(f => f.Warehouse)
                  .WithOne(p => p.Inventory)
                      .HasForeignKey(p => p.InventoryId);


            builder.HasOne(f => f.Product)
                .WithOne(s => s.Inventory)
                    .HasForeignKey<Inventory>(s => new { s.ProductSKU, s.ProductId });
        }
    }
}
