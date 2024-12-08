using UniWebShop.DataAccess.Models;
using System.Diagnostics.CodeAnalysis;

namespace UniWebShop.Backend.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
        public required string Email { get; set; }

        [SetsRequiredMembers]
        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}
