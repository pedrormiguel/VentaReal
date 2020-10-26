using Microsoft.AspNetCore.Mvc;
using VentaReal.API.Models.Request;

namespace VentaReal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Authentificar([FromBody] AuthRequest model)
        {
            return Ok(model);
        }
    }
}