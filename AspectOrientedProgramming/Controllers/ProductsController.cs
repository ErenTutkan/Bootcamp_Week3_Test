using AspectOrientedProgramming.Interceptors;
using AspectOrientedProgramming.Models;
using AspectOrientedProgramming.Repositories;
using AspectOrientedProgramming.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspectOrientedProgramming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _services;

        public ProductsController(IProductService services)
        {
            _services = services;
        }
        [HttpGet]
        
        public IActionResult GetAll()
        {
            return Ok(_services.GetAll());
            
        }
        [HttpPost]
        public IActionResult Save(Product product)
        {
            _services.Save(product);
            return Created("",null);
        }
    }
}
