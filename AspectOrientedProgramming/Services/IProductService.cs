using AspectOrientedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgramming.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(int id);
        bool Save(Product product);
        bool Delete(int id);
        bool Update(Product product);
    }
}
