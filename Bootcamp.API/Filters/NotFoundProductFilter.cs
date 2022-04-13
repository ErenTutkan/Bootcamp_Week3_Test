using Bootcamp.API.DTOs;
using Bootcamp.API.Query.Product.GetById;
using Bootcamp.API.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.API.Filters
{
    public class NotFoundProductFilter : ActionFilterAttribute
    {
        private readonly IProductRepository _productRepository;
       

        public NotFoundProductFilter(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.HttpContext.Request.RouteValues["id"];
            var idValue = int.Parse(id.ToString());
            var hasProduct =await _productRepository.GetById(new GetByIdProductQuery() { Id = idValue });
            if (hasProduct != null)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>.Fail("Böyle Bir Veri Bulunanamıştır",404));
        }
    }
}
