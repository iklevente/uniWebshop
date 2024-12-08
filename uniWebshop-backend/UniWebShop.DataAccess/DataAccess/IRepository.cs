namespace UniWebShop.DataAccess.DataAccess
{
    internal interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
    }
}
