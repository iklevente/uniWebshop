using UniWebShop.DataAccess.DataAccess;
using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories.Core
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UniWebShopDbContext dbContext) : base(dbContext)
        { }

        public override async Task<User> AddAsync(User entity)
        {
            await myDbContext.Users.AddAsync(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public override Task<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> users = myDbContext.Users;
            return Task.FromResult(users);
        }

        public override Task<User?> GetByIdAsync(Guid id)
        {
            var user = myDbContext.Users.FirstOrDefault(user => user.Id == id);
            return Task.FromResult(user);
        }

        public override async Task<bool> RemoveAsync(User entity)
        {
            myDbContext.Remove(entity);
            await myDbContext.SaveChangesAsync();
            return false;
        }

        public override async Task<bool> RemoveByIdAsync(Guid id)
        {
            var user = myDbContext.Users.FirstOrDefault(user => user.Id == id);
            if (user is not null)
            {
                return await RemoveAsync(user);
            }
            return false;
        }

        public override async Task<User> UpdateAsync(User entity)
        {
            myDbContext.Update(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
