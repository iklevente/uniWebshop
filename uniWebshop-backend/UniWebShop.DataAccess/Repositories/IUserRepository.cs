using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User entity);

        public Task<IEnumerable<User>> GetAllAsync();

        public Task<User?> GetByIdAsync(Guid id);

        public Task<bool> RemoveAsync(User entity);

        public Task<bool> RemoveByIdAsync(Guid id);

        public Task<User> UpdateAsync(User entity);
    }
}
