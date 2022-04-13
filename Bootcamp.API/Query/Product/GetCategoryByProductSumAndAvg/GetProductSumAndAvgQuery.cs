using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetCategoryByProductSumAndAvg
{
    public class GetProductSumAndAvgQuery:IRequest<ResponseDto<ProductSumAndAvgDto>>
    {
        public int CategoryId { get; set; }
    }
}
