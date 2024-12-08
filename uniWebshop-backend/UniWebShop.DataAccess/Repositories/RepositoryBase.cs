using UniWebShop.DataAccess.DataAccess;

namespace UniWebShop.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UniWebShopDbContext myDbContext;

        protected RepositoryBase(UniWebShopDbContext dbContext)
        {
            myDbContext = dbContext;
        }

        public abstract Task<TEntity> AddAsync(TEntity entity);

        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        public abstract Task<TEntity?> GetByIdAsync(Guid id);

        public abstract Task<bool> RemoveAsync(TEntity entity);

        public abstract Task<bool> RemoveByIdAsync(Guid id);

        protected void SaveChanges()
        {
            myDbContext.SaveChanges();
        }

        protected async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await myDbContext.SaveChangesAsync(cancellationToken);
        }

        public abstract Task<TEntity> UpdateAsync(TEntity entity);
    }
}
