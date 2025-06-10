using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Pedidos;
using RestaurantMyC_Api.Services.Platos;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private readonly IPlatosService _service;

        public PlatosController(IPlatosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarPedidos()
        {
            var mesa = await _service.GetAllPlatos();
            return Ok(mesa);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Plato plato)
        {
            var filas = await _service.Create(plato);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Plato plato)
        {
            var filas = await _service.Update(plato);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int idplato)
        {
            var filas = await _service.Delete(idplato);
            if (filas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
