using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class WareHouseMapping : IEntityTypeConfiguration<Warehouses>
    {
        public void Configure(EntityTypeBuilder<Warehouses> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(p => p.Locality).IsRequired();

            builder.Property(p => p.Type).IsRequired();

        }
    }
}
