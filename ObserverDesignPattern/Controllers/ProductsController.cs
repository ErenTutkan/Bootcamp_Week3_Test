using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObserverDesignPattern.Model;
using ObserverDesignPattern.Services;

namespace ObserverDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productService.GetById(id));
        }
        [HttpPost]
        public IActionResult Save(Product newProduct)
        {
            _productService.Save(newProduct);
            return Created("",null);
        }
    }
}
