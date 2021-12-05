using Domain.Entities;
using Domain.Interfaces.Services.Common;

namespace Domain.Interfaces.Services
{
    public interface IProductService : IService<Product>
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long sku);
        bool ValidationId(long sku);

    }
}
