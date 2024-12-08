using UniWebShop.DataAccess.DataAccess;
using UniWebShop.DataAccess.Models;

namespace UniWebShop.DataAccess.Repositories.Core
{
    public class UserQuestionRepository : RepositoryBase<UserQuestion>, IUserQuestionRepository
    {
        public UserQuestionRepository(UniWebShopDbContext dbContext) : base(dbContext)
        { }

        public override async Task<UserQuestion> AddAsync(UserQuestion entity)
        {
            await myDbContext.UserQuestions.AddAsync(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public override Task<IEnumerable<UserQuestion>> GetAllAsync()
        {
            IEnumerable<UserQuestion> userQuestions = myDbContext.UserQuestions;
            return Task.FromResult(userQuestions);
        }

        public override Task<UserQuestion?> GetByIdAsync(Guid id)
        {
            var result = myDbContext.UserQuestions.FirstOrDefault(userQuestion => userQuestion.ID == id);
            return Task.FromResult(result);
        }

        public override async Task<bool> RemoveAsync(UserQuestion entity)
        {
            myDbContext.Remove(entity);
            await myDbContext.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> RemoveByIdAsync(Guid id)
        {
            var userQuestion = myDbContext.UserQuestions.FirstOrDefault(userQuestion => userQuestion.ID == id);
            if (userQuestion is not null)
            {
                return await RemoveAsync(userQuestion);
            }
            return false;
        }

        public override async Task<UserQuestion> UpdateAsync(UserQuestion entity)
        {
            myDbContext.Update(entity);
            await myDbContext.SaveChangesAsync();
            return await Task.FromResult(entity);
        }
    }
}
