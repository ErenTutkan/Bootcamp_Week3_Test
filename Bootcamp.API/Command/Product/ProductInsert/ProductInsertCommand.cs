using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductInsert
{
    public class ProductInsertCommand:IRequest<ResponseDto<int>>
    {
        public ProductInsertRequestDto newProduct { get; set; }
    }
}
