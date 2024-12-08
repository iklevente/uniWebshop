using UniWebShop.DataAccess.DataAccess;
using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories.Core
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(UniWebShopDbContext dbContext) : base(dbContext)
        { }
        public override async Task<Product> AddAsync(Product entity)
        {
            await myDbContext.Products.AddAsync(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public override Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> products = myDbContext.Products;
            return Task.FromResult(products);
        }

        public override Task<Product?> GetByIdAsync(Guid id)
        {
            var product = myDbContext.Products.FirstOrDefault(product => product.Id == id);
            return Task.FromResult(product);
        }

        public override async Task<bool> RemoveAsync(Product entity)
        {
            myDbContext.Remove(entity);
            await myDbContext.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> RemoveByIdAsync(Guid id)
        {
            var product = myDbContext.Products.FirstOrDefault(product => product.Id == id);
            if (product is not null)
            {
                return await RemoveAsync(product);
            }
            return false;
        }

        public override async Task<Product> UpdateAsync(Product entity)
        {
            myDbContext.Update(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
