using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Models;

namespace api.Services
{
    public interface IUserService
    {
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO?> GetByEmailAsync(string email);
        Task CreateAsync(CreateUserDTO createUserDTO);
    }
}