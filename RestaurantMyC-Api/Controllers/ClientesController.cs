using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Clientes;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }    

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Cliente cliente)
        {
            var filas = await _service.Create(cliente);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Cliente cliente)
        {
            var filas = await _service.Update(cliente);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var filas = await _service.Delete(id);
            if (filas == 0) {
                return NotFound();
            }         
            return NoContent();
        }
    }
}
