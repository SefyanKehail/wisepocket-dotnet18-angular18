using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Models;
using api.Repositories;
using api.Utilities;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordUtils _passwordUtils;
        public UserService(IUserRepository userRepository, PasswordUtils passwordUtils)
        {
            _userRepository = userRepository;
            _passwordUtils = passwordUtils;
        }
        public async Task CreateAsync(CreateUserDTO createUserDTO)
        {
            var user = new User
            {
                Name = createUserDTO.Name,
                Email = createUserDTO.Email,
                Password = _passwordUtils.Hash(createUserDTO.Password)
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<UserDTO?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null){
                throw new UserNotFoundException();
            }

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            
            if (user == null){
                throw new UserNotFoundException();
            }

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }
    }
}