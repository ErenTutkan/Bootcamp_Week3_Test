using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetCategoryByProductSumAndAvg
{
    public class GetProductSumAndAvgQueryHandler : IRequestHandler<GetProductSumAndAvgQuery, ResponseDto<ProductSumAndAvgDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductSumAndAvgQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<ProductSumAndAvgDto>> Handle(GetProductSumAndAvgQuery request, CancellationToken cancellationToken)
        {
            var result =await _productRepository.GetProductSumAndAvg(request.CategoryId);
            return ResponseDto<ProductSumAndAvgDto>.Success(result, 200);
           
        }
    }
}
