using AspectOrientedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgramming.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product(){Id = 1, Name ="Kalem"},
            new Product(){Id = 2, Name ="Silgi"}
        };
        public Product Get(int id)=>_products.FirstOrDefault(p => p.Id == id);

        public List<Product> GetAll() => _products;

        public void Save(Product product)=>_products.Add(product);

        public void Update(Product updateProduct)
        {
            var product=_products.FirstOrDefault(p => p.Id == updateProduct.Id);
            var productIndex=_products.IndexOf(product);
            _products[productIndex] = updateProduct;
        }
        public void Delete(int id)
        {
            var product=_products.FirstOrDefault(p => p.Id == id);
            _products.Remove(product);
        }

    }
}
