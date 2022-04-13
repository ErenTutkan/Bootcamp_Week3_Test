using AutoMapper;
using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Query.Product.GetAll
{
    public class GetAllProductQueryHandler:IRequestHandler<GetAllProductQuery,ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAll();
           
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(result), 200);
        }
    }
}
