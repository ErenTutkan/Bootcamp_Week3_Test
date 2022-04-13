using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetProductNameAndPrice
{
    public class GetProductNameAndPriceQuery:IRequest<ResponseDto<ProductNameAndPriceDto>>
    {
        public int Id { get; set; }
    }
}
