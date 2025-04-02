using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_USUARIOS.Models;
using API_USUARIOS.Models.DTOs;
using API_USUARIOS.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_USUARIOS.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService iUserService)
        {
            _userService = iUserService;
        }

        [HttpGet("ListarTodosUsuarios")]
        public async Task<ActionResult<UserModelResponse<List<UserModel>>>> ListarUsuarios()
        {
            var users = await _userService.ListarUsuarios();
            return Ok(users);
        }
    }
}