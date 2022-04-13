using Bootcamp.API.Command.Product.ProductDelete;
using Bootcamp.API.Command.Product.ProductInsert;
using Bootcamp.API.Command.Product.ProductUpdate;
using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Bootcamp.API.Query.Product.GetById;
using Bootcamp.API.Query.Product.GetWithPaging;

namespace Bootcamp.API.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetByWithPage(GetByWithPagingProductQuery getByWithPagingProduct);
        Task<ProductFullDto> GetById(GetByIdProductQuery getByIdProductQuery);
        Task<int> Save(ProductInsertCommand productInsertCommand);
        Task<bool> Delete(ProductDeleteCommand request);
        Task<bool> Update(ProductUpdateCommand productUpdateCommand);
        Task<string> GetCategoryNameByProduct(int id);
        Task<ProductSumAndAvgDto> GetProductSumAndAvg(int id);
        Task<ProductNameAndPriceDto> GetProductNameAndPrice(int id);
    }
}
