using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_USUARIOS.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("TEste");
    }
    }
}