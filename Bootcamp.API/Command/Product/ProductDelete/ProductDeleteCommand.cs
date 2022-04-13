using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductDelete
{
    public class ProductDeleteCommand:IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
    }
}
