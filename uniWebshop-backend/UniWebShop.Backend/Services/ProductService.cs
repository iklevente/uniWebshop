using UniWebShop.Backend.DTOs;
using UniWebShop.DataAccess.Models;
using UniWebShop.DataAccess.Repositories;

namespace UniWebShop.Backend.Services
{
    public class ProductService
    {
        private readonly IProductRepository myRepository;

        public ProductService(IProductRepository repository)
        {
            myRepository = repository;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> products = await myRepository.GetAllAsync();
            List<ProductDTO> resultProducts = new();
            foreach (Product product in products)
            {
                resultProducts.Add(new ProductDTO(product));
            }
            return resultProducts;
        }
        public async Task<ProductDTO?> GetByIdAsync(Guid id)
        {
            Product? product = await myRepository.GetByIdAsync(id);
            return product is not null ? new ProductDTO(product) : null;
        }
        public async Task AddAsync(Product product) => await myRepository.AddAsync(product);
        public async Task RemoveByIdAsync(Guid id) => await myRepository.RemoveByIdAsync(id);
        public async Task UpdateAsync(Product product) => await myRepository.UpdateAsync(product);
    }
}
