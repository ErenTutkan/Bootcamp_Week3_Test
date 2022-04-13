
using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetAll
{
    public class GetAllProductQuery:IRequest<ResponseDto<List<ProductDto>>>
    {
      
    }
}
