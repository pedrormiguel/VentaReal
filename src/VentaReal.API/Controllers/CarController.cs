using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VentaReal.API.Data.Services;
using VentaReal.API.Entities;
using VentaReal.API.Orm;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VentaReal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CarController : ControllerBase
    {
        private ICarServices _carservices;

        public CarController(ICarServices car)
        {
            _carservices = car;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var output = new Response();
            
            try
            {
                var data = await _carservices.GetAllCar();

                output.data = data;
                output.exito = 1.0;
                output.message = "OK";

                return Ok(output);
            }
            catch (Exception e)
            {

                output.data = null;
                output.exito = 0;
                output.message = e.Message;
                
                return BadRequest(output);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car car)
        {
            var output = new Response();

            try
            {
                 await _carservices.AddCar(car);

                output.data = car;
                output.exito = 1;
                output.message = "Agregado con exito.";

                 return Ok(output);
            }
            catch (Exception e)
            {
                output.data = null;
                output.exito = 0;
                output.message = e.Message;

                 return BadRequest(output);
            }
           
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var output = new Response();

            try
            {
                await _carservices.DeleteCar(Id);

                output.exito = 1;
                output.message = "Borrado con Exito.";

                return Ok(output);

            }
            catch (Exception e)
            {
                output.exito = 0;
                output.message = e.Message;

                return BadRequest(output);
            }
 
        }

        [HttpPut]
        public async Task<IActionResult> Update(Car car)
        {
            await _carservices.UpdateCar(car);

            return Ok(car);
        }
         
    }


}
