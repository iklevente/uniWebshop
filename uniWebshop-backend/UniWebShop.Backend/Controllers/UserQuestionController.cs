using UniWebShop.Backend.DTOs;
using UniWebShop.Backend.Services;
using UniWebShop.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniWebShop.Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserQuestionController : ControllerBase
    {
        private readonly UserQuestionService myUserQuestionService;

        public UserQuestionController(UserQuestionService userQuestionService)
        {
            myUserQuestionService = userQuestionService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserQuestionDTO>> GetAsync()
        {
            return await myUserQuestionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserQuestionDTO?> GetUserQuestionByIdAsync(Guid id)
        {
            return await myUserQuestionService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAsync([FromBody] UserQuestion userQuestion)
        {
            await myUserQuestionService.AddAsync(userQuestion);
        }

        [HttpDelete("{id}")]
        public async Task RemoveAsync(Guid id)
        {
            await myUserQuestionService.RemoveByIdAsync(id);
        }
        [HttpPut]
        public async Task UpdateAsync([FromBody] UserQuestion userQuestion)
        {
            await myUserQuestionService.UpdateAsync(userQuestion);
        }
    }
}
