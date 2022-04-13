using ObserverDesignPattern.Model;
using ObserverDesignPattern.Observers;
using ObserverDesignPattern.Repository;
using ObserverDesignPattern.Subjects;

namespace ObserverDesignPattern.Services
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

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Save(Product product)
        {
            _repository.Save(product);
            var o = new CreatedProductSubject();
            o.Subscribe(new CreatedProductSendMailObserver());
            o.Subscribe(new CreatedProductSendSmsObserver());
            o.Notify(product.Id,product.Name);
            return true;
        }

        public bool Update(Product product)
        {
            _repository.Update(product);
            return true;
        }
    }
}
