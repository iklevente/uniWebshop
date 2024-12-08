using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories
{
    public interface IUserQuestionRepository
    {
        public Task<UserQuestion> AddAsync(UserQuestion entity);

        public Task<IEnumerable<UserQuestion>> GetAllAsync();

        public Task<UserQuestion?> GetByIdAsync(Guid id);

        public Task<bool> RemoveAsync(UserQuestion entity);

        public Task<bool> RemoveByIdAsync(Guid id);

        public Task<UserQuestion> UpdateAsync(UserQuestion entity);
    }
}
