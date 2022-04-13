using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetProductNameAndPrice
{
    public class GetProductNameAndPriceQueryHandler : IRequestHandler<GetProductNameAndPriceQuery, ResponseDto<ProductNameAndPriceDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductNameAndPriceQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<ProductNameAndPriceDto>> Handle(GetProductNameAndPriceQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductNameAndPrice(request.Id);
            return ResponseDto<ProductNameAndPriceDto>.Success(result,200);
        }
    }
}
