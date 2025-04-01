using Microsoft.AspNetCore.Mvc;

namespace DOTNET_DAPPER.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmesController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("TEste");
    }

}