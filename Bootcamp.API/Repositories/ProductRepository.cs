using Bootcamp.API.Command.Product.ProductDelete;
using Bootcamp.API.Command.Product.ProductInsert;
using Bootcamp.API.Command.Product.ProductUpdate;
using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Bootcamp.API.Query.Product.GetById;
using Bootcamp.API.Query.Product.GetWithPaging;
using Dapper;
using System.Data;

namespace Bootcamp.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> Delete(ProductDeleteCommand request)
        {
            var command = "delete from products where id=@id";
            return await _connection.ExecuteAsync(command,request)>0;
           
        }

        public async Task<List<Product>> GetAll()
        {
            var query = "select * from getallproducts";
            var result=await _connection.QueryAsync<Product>(query);
            return result.ToList();
        }

        public async Task<ProductFullDto> GetById(GetByIdProductQuery getByIdProductQuery)
        {
            var query = "func_getbyid_product";
            var result =await _connection.QuerySingleAsync<ProductFullDto>(query, new {p_id=getByIdProductQuery.Id},commandType:CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<Product>> GetByWithPage(GetByWithPagingProductQuery getByWithPagingProduct)
        {
            var pagesize=getByWithPagingProduct.PageSize;
            var offset=(getByWithPagingProduct.Page-1)* pagesize;
            var query = $"select * from products limit {pagesize} offset {offset}";
            var result= await _connection.QueryAsync<Product>(query);
            return result.ToList();
        }

        public async Task<int> Save(ProductInsertCommand productInsertCommand)
        {
            var command = "Insert into products(name,price,stock,color,categoryid) values(@name,@price,@stock,@color,@categoryid) returning id";
            var id=await _connection.ExecuteScalarAsync<int>(command, productInsertCommand.newProduct);
            return id;
        }

        public async Task<bool> Update(ProductUpdateCommand productUpdateCommand)
        {
            var command = "call sp_product_update(@id,@name,@price,@stock,@color,@categoryid)";
            var result = await _connection.ExecuteAsync(command, productUpdateCommand.updateProduct);
            return result==-1;
        }

        public async Task<string> GetCategoryNameByProduct(int id)
        {
            var command = "func_get_product_category_name";
            var result = await _connection.QuerySingleAsync<string>(command, new { p_id = id }, commandType: CommandType.StoredProcedure);
            return result;
        }
        public async Task<ProductSumAndAvgDto> GetProductSumAndAvg(int id)
        {
            var command = "func_product_sum_and_avg_category";
            
            var result=await _connection.QuerySingleAsync(command,new {category_id=id}, commandType: CommandType.StoredProcedure);
            return new ProductSumAndAvgDto() { SumPrice=(decimal)result.sum_price,AvgPrice=(decimal)result.avg_price};
        }
        public async Task<ProductNameAndPriceDto> GetProductNameAndPrice(int id)
        {
            var command = "get_product_name_price";
            var result=await _connection.QuerySingleAsync(command, new {p_id=id}, commandType: CommandType.StoredProcedure);
            return new ProductNameAndPriceDto() { Name=(string)result.p_name, Price= (decimal)result.p_price};
        }
        
    }
}
