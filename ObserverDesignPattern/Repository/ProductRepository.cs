using ObserverDesignPattern.Model;

namespace ObserverDesignPattern.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products=new List<Product>()
        {
            new Product(){ Id = 1, Name ="Defter",Price=5,Stock=10},
            new Product(){ Id = 2, Name ="Kalem",Price=5,Stock=10},
            new Product(){ Id = 3, Name ="Masa",Price=5,Stock=10},
            new Product(){ Id = 4, Name ="Sandalye",Price=5,Stock=10},
            new Product(){ Id = 5, Name ="Dolap",Price=5,Stock=10},
        };
        public List<Product> GetAll() => _products;
        public Product GetById(int id) => _products.FirstOrDefault(x => x.Id==id);
        public void Delete(int id)
        {
            var product= _products.FirstOrDefault(x => x.Id==id);
            _products.Remove(product);
        }
        public void Save(Product newProduct)
        {
            _products.Add(newProduct);
        }

        public void Update(Product updateProduct)
        {
            var product = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            var productindex=_products.IndexOf(product);
            _products[productindex] = updateProduct;
        }
    }
}
