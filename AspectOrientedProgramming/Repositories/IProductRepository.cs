using AspectOrientedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgramming.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        void Save(Product product);
        void Update(Product updateProduct);
        void Delete(int id);
    }
}
