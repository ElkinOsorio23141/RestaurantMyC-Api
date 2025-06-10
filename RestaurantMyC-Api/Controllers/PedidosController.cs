using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Clientes;
using RestaurantMyC_Api.Services.Pedidos;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _service;

        public PedidosController(IPedidosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarPedidos()
        {
            var mesa = await _service.GetAllPedidos();
            return Ok(mesa);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] Pedido pedido)
        {
            var filas = await _service.Create(pedido);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] Pedido pedido)
        {
            var filas = await _service.Update(pedido);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int idpedido)
        {
            var filas = await _service.Delete(idpedido);
            if (filas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
