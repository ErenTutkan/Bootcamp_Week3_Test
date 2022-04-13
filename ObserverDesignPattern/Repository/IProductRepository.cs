using ObserverDesignPattern.Model;

namespace ObserverDesignPattern.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Save(Product newProduct);
        void Update(Product updateProduct);
        void Delete(int id);
    }
}
