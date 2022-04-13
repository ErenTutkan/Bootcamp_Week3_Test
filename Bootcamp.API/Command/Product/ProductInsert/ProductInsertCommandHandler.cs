using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductInsert
{
    public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, ResponseDto<int>>
    {
        private readonly IProductRepository _productrepository;
        public ProductInsertCommandHandler(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public async Task<ResponseDto<int>> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            var result = await _productrepository.Save(request);
            return ResponseDto<int>.Success(result, 201);
        }
    }
}
