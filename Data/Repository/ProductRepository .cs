using Data.Context;
using Data.Repository.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DBContextAPI db) : base(db)
        {
        }

        public bool ValidationId(long sku)
        {
            return DbSet.Any(c => c.SKU == sku);
        }
        public override async Task<List<Product>> FindAll()
        {
            return await Db.Product
                            .AsNoTrackingWithIdentityResolution()
                            .Include(p => p.Inventory)
                                .ThenInclude(p => p.Warehouse)
                            .ToListAsync();
        }
        public override async Task<Product> FindById(long sku)
        {

            return await DbSet.Include(p => p.Inventory)
                                    .ThenInclude(c => c.Warehouse)
                             .Where(d => d.SKU == sku)
                             .AsNoTracking()
                             .FirstOrDefaultAsync();
        }
    }
}
