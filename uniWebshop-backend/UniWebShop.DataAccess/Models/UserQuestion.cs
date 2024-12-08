using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniWebShop.DataAccess.Models
{
    public class UserQuestion
    {
        [Key]
        public Guid ID { get; init; }

        [MinLength(10)]
        [MaxLength(50)]
        [Required]
        public required string Question { get; set; }

        [MinLength(10)]
        [MaxLength(250)]
        public string? Answer { get; set; }

        [Required]
        [ForeignKey("Users")]
        public required Guid UserId { get; init; }

        public UserQuestion(string question, string answer, Guid userId)
        {
            ID = Guid.NewGuid();
            Question = question;
            Answer = answer;
            UserId = userId;
        }
        public UserQuestion(string question, Guid userId)
        {
            ID = Guid.NewGuid();
            Question = question;
            UserId = userId;
        }
        /// <summary>
        /// Only for EF
        /// </summary>
        public UserQuestion() { }

        public override bool Equals(object? obj)
        {
            return obj is UserQuestion question &&
                GetHashCode() == question.GetHashCode() &&
                ID.Equals(question.ID) &&
                Question == question.Question &&
                Answer == question.Answer &&
                UserId.Equals(question.UserId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Question, Answer, UserId);
        }
    }
}
