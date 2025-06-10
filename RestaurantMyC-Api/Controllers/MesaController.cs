using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Clientes;
using RestaurantMyC_Api.Services.Mesas;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _service;
        public MesaController(IMesaService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarMesas()
        {
            var mesa = await _service.GetAllMesas();
            return Ok(mesa);
        }

        [HttpPost]
        [Route("Agregar")]      
        public async Task<IActionResult> Agregar([FromBody] Mesa mesa)
        {
            var filas = await _service.Create(mesa);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Mesa mesa)
        {
            var filas = await _service.Update(mesa);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int idMesa)
        {
            var filas = await _service.Delete(idMesa);
            if (filas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
