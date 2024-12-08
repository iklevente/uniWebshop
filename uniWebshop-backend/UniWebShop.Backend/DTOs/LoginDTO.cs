using Microsoft.IdentityModel.Tokens;

namespace UniWebShop.Backend.DTOs
{
    public class LoginDTO
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }

        public LoginDTO(string loginData, string password)
        {
            if (loginData.Contains('@'))
            {
                Email = loginData;
            }
            else
            {
                UserName = loginData;
            }
            Password = password;
        }
        public LoginDTO() { }

    }
}
