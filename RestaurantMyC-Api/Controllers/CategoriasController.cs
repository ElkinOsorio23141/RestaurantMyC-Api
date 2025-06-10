using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantMyC_Api.Models;
using RestaurantMyC_Api.Services.Categorias;
using RestaurantMyC_Api.Services.Clientes;

namespace RestaurantMyC_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> ListarCategorias()
        {
            var mesa = await _service.GetAllCategorias();
            return Ok(mesa);
        }

        [HttpPost]
        [Route("Agregar")]

        public async Task<IActionResult> Agregar([FromBody] CategoriasPlatos categoria)
        {
            var filas = await _service.Create(categoria);
            return Ok(filas);
        }

        [HttpPut]
        [Route("Modificar")]
        public async Task<IActionResult> Modificar([FromBody] CategoriasPlatos categoria)
        {
            var filas = await _service.Update(categoria);
            return Ok(filas);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var filas = await _service.Delete(id);
            if (filas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
