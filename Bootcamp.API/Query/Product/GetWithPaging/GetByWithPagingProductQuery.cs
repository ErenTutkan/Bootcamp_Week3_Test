using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetWithPaging
{
    public class GetByWithPagingProductQuery:IRequest<ResponseDto<List<ProductDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
