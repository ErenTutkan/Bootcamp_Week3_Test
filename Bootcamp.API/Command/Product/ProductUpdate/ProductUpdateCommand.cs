using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductUpdate
{
    public class ProductUpdateCommand:IRequest<ResponseDto<NoContent>>
    {
        public ProductUpdateRequestDto updateProduct { get; set; }
    }
}
