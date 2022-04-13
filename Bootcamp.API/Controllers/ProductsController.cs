using Bootcamp.API.Command.Product.ProductDelete;
using Bootcamp.API.Command.Product.ProductInsert;
using Bootcamp.API.Command.Product.ProductUpdate;
using Bootcamp.API.Filters;
using Bootcamp.API.Query.Product.GetAll;
using Bootcamp.API.Query.Product.GetByCategoryName;
using Bootcamp.API.Query.Product.GetById;
using Bootcamp.API.Query.Product.GetCategoryByProductSumAndAvg;
using Bootcamp.API.Query.Product.GetProductNameAndPrice;
using Bootcamp.API.Query.Product.GetWithPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerCustomBase
    {
        private readonly IMediator _meditor;

        public ProductsController(IMediator meditor)
        {
            _meditor = meditor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return CreateActionResult(await _meditor.Send(new GetAllProductQuery()));
        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateActionResult(await _meditor.Send(new GetByIdProductQuery() { Id=id}));
        }
        [HttpGet("GetCategoryNameByProduct/{id:int}")]
        public async Task<IActionResult> GetCategoryNameByProduct(int id)
        {
            return CreateActionResult(await _meditor.Send(new GetCategoryNameByProductQuery(){ Id=id}));
        }
        [HttpGet("GetProductSumAndAvg/{id:int}")]
        public async Task<IActionResult> GetProductSumAndAvg(int id)
        {
            return CreateActionResult(await _meditor.Send(new GetProductSumAndAvgQuery() { CategoryId= id }));

        }
        [HttpGet("GetProductNameAndPrice/{id:int}")]
        public async Task<IActionResult> GetProductNameAndPrice(int id)
        {
            return CreateActionResult(await _meditor.Send(new GetProductNameAndPriceQuery() { Id=id}));
        }
        [HttpGet("Paging/{page:int}/{pageSize:int}")]
        public async Task<IActionResult> GetWithPaging(int page, int pageSize)
        {
            return CreateActionResult(await _meditor.Send(new GetByWithPagingProductQuery() { Page=page,PageSize=pageSize}));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductInsertCommand productInsertCommand)
        {
            
            return CreateActionResult(await _meditor.Send(productInsertCommand));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateCommand productUpdateCommand)
        {
            return CreateActionResult(await _meditor.Send(productUpdateCommand));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(ProductDeleteCommand productDeleteCommand)
        {
            return CreateActionResult(await _meditor.Send(productDeleteCommand));
        }
    }
}
