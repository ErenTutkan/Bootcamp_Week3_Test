using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetById
{
    public class GetByIdProductQuery:IRequest<ResponseDto<ProductFullDto>>
    {
        public int Id { get; set; }
    }
}
