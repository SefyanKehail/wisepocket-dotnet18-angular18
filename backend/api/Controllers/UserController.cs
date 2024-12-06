using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Exceptions;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO createUserDTO)
        {
            await _userService.CreateAsync(createUserDTO);

            // probably refactor this to IActionResult with a location header pointing at the created user using the GetUserById route 
            return Ok(createUserDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userDTO = await _userService.GetByIdAsync(id);
                return Ok(userDTO);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }

}