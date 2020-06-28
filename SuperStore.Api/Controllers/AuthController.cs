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
        public async Task<IActionResult> PostAsync(User userDto)
        {
            // var user = _mapper.Map<User>(userDto);
            var user  =  await _userService.CreateUserAsync(userDto);
            var response = new SingleResponse<User>();
            // var userForDetailedDto = _mapper.Map<UserDto>(response);
            response.Model = user;
            response.Message = "success";
            return response.ToHttpResponse();
        }
    }
}