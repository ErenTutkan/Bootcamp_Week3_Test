using AspectOrientedProgramming.Models;
using FluentValidation;

namespace AspectOrientedProgramming.Validation.FluentValidation
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
