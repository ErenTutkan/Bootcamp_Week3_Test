using Bootcamp.API.Command.Product.ProductInsert;
using Bootcamp.API.DTOs;
using FluentValidation;

namespace Bootcamp.API.Validation.FluentValidation
{
    public class ProductInsertCommandValidation:AbstractValidator<ProductInsertCommand>
    {
        public ProductInsertCommandValidation()
        {
            RuleFor(x=>x.newProduct.Name).NotEmpty().MaximumLength(100);
            RuleFor(x=>x.newProduct.Price).NotEmpty().ExclusiveBetween(0,100000);
            
        }
    }
}
