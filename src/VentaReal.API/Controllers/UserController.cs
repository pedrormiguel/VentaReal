using Microsoft.AspNetCore.Mvc;
using VentaReal.API.Models.Request;
using VentaReal.API.Orm;
using VentaReal.API.Service;

namespace VentaReal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Authentificar([FromBody] AuthRequest model)
        {
            var userResponse    = _userService.Auth(model);
            var response        = new Response();

            if(userResponse == null)
            {
               response.message = "Usuario o contraseña incorrecta";
               return BadRequest(response);
            }

            response.exito = 1;
            response.data  = userResponse;
            response.message = "Logueado con exicto";

            return Ok(response);
        }

        
    }
}