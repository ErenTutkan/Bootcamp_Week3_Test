using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Query.Product.GetByCategoryName
{
    public class GetCategoryNameByProductQuery:IRequest<ResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
