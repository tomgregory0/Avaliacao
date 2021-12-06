using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services.Common;
using System;

namespace Domain.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (product.SKU == 0)
                throw new Exception("Não foi possível cadastrar o produto!");

            var productGet = _productRepository.FindById(product.SKU);
            if (productGet.Result?.SKU > 0)
                throw new Exception($"Não foi possivel cadastrar o produto, SKU {productGet.Result?.SKU} duplicado!");

            _productRepository.Add(product);
        }

        public void DeleteProduct(long sku)
        {
            var productGet = _productRepository.FindById(sku);
            if (!(productGet.Result?.SKU > 0))
                throw new Exception($"Produto não existente!");

            _productRepository.Delete(productGet.Result);
        }


        public void UpdateProduct(Product product)
        {
            try
            {
                if (product?.SKU is not null)
                {
                    var data = _productRepository.FindById(product.SKU);


                    if (data.Result is not null)
                    {
                        var productData = data.Result;
                        productData.Name = product.Name;
                        productData.Inventory = product.Inventory;
                        _productRepository.Update(productData);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }

        }

        public bool ValidationId(long sku)
        {
            return _productRepository.ValidationId(sku);
        }

    }
}
