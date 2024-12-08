using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> AddAsync(Product entity);

        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product?> GetByIdAsync(Guid id);

        public Task<bool> RemoveAsync(Product entity);

        public Task<bool> RemoveByIdAsync(Guid id);

        public Task<Product> UpdateAsync(Product entity);
    }
}
