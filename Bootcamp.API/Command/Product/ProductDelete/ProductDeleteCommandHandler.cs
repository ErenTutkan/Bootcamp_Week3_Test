﻿using Bootcamp.API.DTOs;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Command.Product.ProductDelete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;
        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<NoContent>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Delete(request);
            if (result)
                return ResponseDto<NoContent>.Success(204);

            return ResponseDto<NoContent>.Fail("Hatalı Bir İşlem Gerçekleşti.", 500);
        }
    }
}

