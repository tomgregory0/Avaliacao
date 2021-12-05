using Domain.Entities;
using Domain.Interfaces.Common;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        bool ValidationId(long sku);
    }
}
