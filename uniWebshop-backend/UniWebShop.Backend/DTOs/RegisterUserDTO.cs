using System.ComponentModel.DataAnnotations;

namespace UniWebShop.Backend.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public string Role { get; set; }

        public RegisterUserDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = "User";
        }
        public RegisterUserDTO(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }
        public RegisterUserDTO() { }
    }
}
