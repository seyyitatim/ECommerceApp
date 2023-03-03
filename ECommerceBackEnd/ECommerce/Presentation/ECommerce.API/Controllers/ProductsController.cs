using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _productWriteRepository.AddRangeAsync(new List<Product>
            {
                new () {Id=Guid.NewGuid(), Name="Product 4", Price = 100, Stock=10},
            });

            await _productWriteRepository.SaveAsync();

            return Ok();

            //await _productWriteRepository.AddAsync(new() { Name = "Product 4", Price = 100, Stock = 10 });

            //return Ok(_productReadRepository.GetByIdAsync("bdfc56bd-ad4f-4c08-8771-97dd52af6dd4"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            var product = await _productReadRepository.GetByIdAsync(id);

            return Ok(product);
        }
    }
}
