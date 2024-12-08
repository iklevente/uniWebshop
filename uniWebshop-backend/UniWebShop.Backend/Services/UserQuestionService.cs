using UniWebShop.Backend.DTOs;
using UniWebShop.DataAccess.Models;
using UniWebShop.DataAccess.Repositories;

namespace UniWebShop.Backend.Services
{
    public class UserQuestionService
    {
        private readonly IUserQuestionRepository myRepository;

        public UserQuestionService(IUserQuestionRepository repository)
        {
            myRepository = repository;
        }
        public async Task<IEnumerable<UserQuestionDTO>> GetAllAsync()
        {
            IEnumerable<UserQuestion> userQuestions = await myRepository.GetAllAsync();
            List<UserQuestionDTO> resultUserQuestions = new();
            foreach (UserQuestion userQuestion in userQuestions)
            {
                resultUserQuestions.Add(new UserQuestionDTO(userQuestion));
            }
            return resultUserQuestions;
        }
        public async Task<UserQuestionDTO?> GetByIdAsync(Guid id)
        {
            UserQuestion? userQuestion = await myRepository.GetByIdAsync(id);
            return userQuestion is not null ? new UserQuestionDTO(userQuestion) : null;
        }
        public async Task AddAsync(UserQuestion userQuestion) => await myRepository.AddAsync(userQuestion);
        public async Task RemoveByIdAsync(Guid id) => await myRepository.RemoveByIdAsync(id);
        public async Task UpdateAsync(UserQuestion userQuestion) => await myRepository.UpdateAsync(userQuestion);
    }
}
