using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetWithPaging
{
    public class GetByWithPagingProductQueryHandler : IRequestHandler<GetByWithPagingProductQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByWithPagingProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ProductDto>>> Handle(GetByWithPagingProductQuery request, CancellationToken cancellationToken)
        {
            var result =await _productRepository.GetByWithPage(request);
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(result),200);
        }
    }
}
