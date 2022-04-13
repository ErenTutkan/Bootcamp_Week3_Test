using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetByCategoryName
{
    public class GetCategoryNameByProductQueryHandler : IRequestHandler<GetCategoryNameByProductQuery, ResponseDto<string>>
    {
        private readonly IProductRepository _repository;

        public GetCategoryNameByProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<string>> Handle(GetCategoryNameByProductQuery request, CancellationToken cancellationToken)
        {
            var categoryname = await _repository.GetCategoryNameByProduct(request.Id);
            return ResponseDto<string>.Success(categoryname,200);
            
        }
    }
}
