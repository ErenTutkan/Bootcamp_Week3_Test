using ObserverDesignPattern.Model;

namespace ObserverDesignPattern.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Save(Product product);
        bool Delete(int id);
        bool Update(Product product);
    }
}
