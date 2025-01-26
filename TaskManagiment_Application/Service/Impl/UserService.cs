﻿using TaskManagiment_Core.DTO;
using TaskManagiment_DataAccess.Authentication;
using TaskManagiment_DataAccess.Model;
using TaskManagiment_DataAccess.Repository;

namespace TaskManagiment_Application.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _users;
        private readonly IEmailService _emailService;

        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepository userRepository,
            IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _users = userRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _users.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return null;

            return new User
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = id,
            };
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _users.GetAllAsync(u => true);
            return users.Select(user => new User
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id
            }).ToList();
        }

        public async Task<User> AddUserAsync(CreateUser userForCreationDTO)
        {
            if (userForCreationDTO == null)
                throw new ArgumentNullException(nameof(userForCreationDTO));

            string randomSalt = Guid.NewGuid().ToString();

            User user = new User
            {
                Email = userForCreationDTO.Email,
                FullName = userForCreationDTO.FullName,
                Id = userForCreationDTO.Id,
                Password = _passwordHasher.Encrypt(
                 password: userForCreationDTO.Password,
                    salt: randomSalt
                  ),
            };
            var res = await _users.AddAsync(user);
            var result = new User
            {
                Email = userForCreationDTO.Email,
                FullName = userForCreationDTO.FullName,
                Id = userForCreationDTO.Id,

            };
            await _emailService.SendEmailAsync(user);

            return user;
        }

        public async Task<User> UpdateUserAsync(Guid id, CreateUser userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto), "UserDTO cannot be null.");

            var user = await _users.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return null;

            user.Email = userDto.Email;
            user.FullName = userDto.FullName;
            user.Id = id;
            user.Password = _passwordHasher.Encrypt(
                    password: userDto.Password,
                    salt: user.Password.Split('.').Last()
                    );
            await _users.UpdateAsync(user);
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _users.GetFirstAsync(u => u.Id == id);

            if (user == null)
                return false;

            await _users.DeleteAsync(user);
            return true;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _users.GetUserByEmailAsync(email);
        }

        public async Task<bool> VerifyPassword(User user, string password)
        {
            return await Task.Run(() => user.Password == password);
        }
    }

}
