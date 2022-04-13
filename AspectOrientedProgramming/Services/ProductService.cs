using AspectOrientedProgramming.Interceptors;
using AspectOrientedProgramming.Models;
using AspectOrientedProgramming.Repositories;
using AspectOrientedProgramming.Validation.FluentValidation;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectOrientedProgramming.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

       
        public bool Delete(int id)
        {
            _repository.Delete(id);
            return true;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

       
        public List<Product> GetAll()
        {
           return _repository.GetAll();
        }
        [ValidationAspect(typeof(ProductValidation))]
        public bool Save(Product product)
        {
            _repository.Save(product);
            return true;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
