using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Api.Models;
using SuperStore.Core.Dto;
using SuperStore.Core.Entities;
using SuperStore.Core.Interfaces;

namespace SuperStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(User userDto)
        {
         
            var user = await _userService.LoginAsync(userDto.UserName, userDto.Password);
            var response = new SingleResponse<User>();
            if (user == null)
            {
                response.Message = "Username or password is incorrect";
            }
            else
            {
                response.Model = user;
                response.Message = "success";
            }
            return response.ToHttpResponse();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserDto userDto)
        {
            var userToCreate = _mapper.Map<User>(userDto);
            var response = new SingleResponse<UserDto>();
            if (await _userService.UserExistsAsync(userDto.UserName))
            {
                response.Message = "Username already exists";
                response.Model = userDto;
            }
            else
            {
                var user = await _userService.CreateUserAsync(userToCreate);


                UserDto userForDetailedDto = _mapper.Map<UserDto>(response);
                response.Model = userForDetailedDto;
                response.Message = "success";
            }
            return response.ToHttpResponse();
        }
    }
}