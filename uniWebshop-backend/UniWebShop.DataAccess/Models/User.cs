using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UniWebShop.DataAccess.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required byte[] Salt { get; set; }

        [Required]
        public required string Role { get; set; }


        [SetsRequiredMembers]
        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = PasswordManagement.GenerateSaltedAndHashedPasword(password, out var salt);
            Salt = salt;
            Role = "User";
        }
        [SetsRequiredMembers]
        public User(string name, string email, string password, string role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = PasswordManagement.GenerateSaltedAndHashedPasword(password, out var salt);
            Salt = salt;
            Role = role;
        }
        /// <summary>
        /// Only for EF
        /// </summary>
        public User() { }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                GetHashCode() == user.GetHashCode() &&
                Id.Equals(user.Id) &&
                Name == user.Name &&
                Email == user.Email &&
                Password == user.Password &&
                Role == user.Role;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email, Password, Role);
        }
    }
}
