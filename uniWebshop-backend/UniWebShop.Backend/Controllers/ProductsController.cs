using UniWebShop.Backend.DTOs;
using UniWebShop.Backend.Services;
using UniWebShop.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniWebShop.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService myProductService;

        public ProductsController(ProductService productService)
        {
            myProductService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAsync()
        {
            return await myProductService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            return await myProductService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync([FromBody] Product product)
        {
            await myProductService.AddAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task RemoveAsync(Guid id)
        {
            await myProductService.RemoveByIdAsync(id);
        }
        [HttpPut]
        public async Task UpdateAsync([FromBody] Product product)
        {
            await myProductService.UpdateAsync(product);
        }
    }
}