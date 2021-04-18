using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int id)
        {
            var result = _userService.GetUserByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updated")]
        public IActionResult Updated(UserForUpdateDto userForUpdateDto)
        {
            var user = _userService.GetUserById(userForUpdateDto.Id);
            var token = _authService.CreateAccessToken(user.Data);

            var result = _userService.Updated(userForUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
