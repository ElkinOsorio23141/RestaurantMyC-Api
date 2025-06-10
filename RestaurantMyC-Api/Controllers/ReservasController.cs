using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Platos;
using RestaurantMyC_Api.Services.Reservas;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReservasService _service;

        public ReservasController(IReservasService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarReservas()
        {
            var mesa = await _service.GetAllReservas();
            return Ok(mesa);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Reserva reserva)
        {
            var filas = await _service.Create(reserva);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Reserva reserva)
        {
            var filas = await _service.Update(reserva);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int idreserva)
        {
            var filas = await _service.Delete(idreserva);
            if (filas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
