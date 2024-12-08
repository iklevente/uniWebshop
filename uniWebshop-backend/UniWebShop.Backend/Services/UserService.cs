using UniWebShop.Backend.DTOs;
using UniWebShop.DataAccess;
using UniWebShop.DataAccess.Models;
using UniWebShop.DataAccess.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace UniWebShop.Backend.Services
{
    public class UserService
    {
        private readonly IUserRepository myRepository;
        public UserService(IUserRepository repository)
        {
            myRepository = repository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            IEnumerable<User> users = await myRepository.GetAllAsync();
            List<UserDTO> resultUsers = new();
            foreach (User user in users)
            {
                resultUsers.Add(new UserDTO(user));
            }
            return resultUsers;
        }
        public async Task<UserDTO?> GetByIdAsync(Guid id)
        {
            User? user = await myRepository.GetByIdAsync(id);
            return user is not null ? new UserDTO(user) : null;
        }
        public async Task AddAsync(RegisterUserDTO registerUserDTO)
        {
            User user = new(registerUserDTO.Name, registerUserDTO.Email, registerUserDTO.Password, registerUserDTO.Role);
            await myRepository.AddAsync(user);
        }

        public async Task RemoveByIdAsync(Guid id) => await myRepository.RemoveByIdAsync(id);
        public async Task UpdateAsync(User user) => await myRepository.UpdateAsync(user);
        public async Task<UserDTO?> ValidateUser(LoginDTO loginDTO)
        {
            User? user;
            if (!loginDTO.UserName.IsNullOrEmpty())
            {
                user = (await myRepository.GetAllAsync()).FirstOrDefault(x => x.Name == loginDTO.UserName);
            }
            else
            {
                user = (await myRepository.GetAllAsync()).FirstOrDefault(x => x.Email == loginDTO.Email);
            }
            if (user is not null && PasswordManagement.VerifyPassword(loginDTO.Password, user.Password, user.Salt))
            {
                return new UserDTO(user);
            }
            else return null;
        }
    }
}
