using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductUpdate
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Update(request);
            if (result)
                return ResponseDto<NoContent>.Success(204);

            return ResponseDto<NoContent>.Fail("Hatalı Bir İşlem Gerçekleşti.",500);
        }
    }
}
