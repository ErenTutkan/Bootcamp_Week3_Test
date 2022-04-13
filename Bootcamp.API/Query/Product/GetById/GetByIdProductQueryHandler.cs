using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ResponseDto<ProductFullDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductFullDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetById(request);
            return ResponseDto<ProductFullDto>.Success(_mapper.Map<ProductFullDto>(result),200);
        }
    }
}
