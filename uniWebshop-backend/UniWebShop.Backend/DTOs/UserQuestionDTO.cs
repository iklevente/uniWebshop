using UniWebShop.DataAccess.Models;
using System.Diagnostics.CodeAnalysis;

namespace UniWebShop.Backend.DTOs
{
    public class UserQuestionDTO
    {
        public Guid ID { get; init; }
        public required string Question { get; set; }
        public string? Answer { get; set; }
        public required Guid UserId { get; init; }

        [SetsRequiredMembers]
        public UserQuestionDTO(UserQuestion userQuestion)
        {
            ID = userQuestion.ID;
            Question = userQuestion.Question;
            Answer = userQuestion.Answer;
            UserId = userQuestion.UserId;
        }
    }
}
