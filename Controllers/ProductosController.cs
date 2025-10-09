using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;
        public ProductosController(IProductoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.CrearAsync(nombre, usuarioId);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] int productoId, [FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.EditarAsync(productoId, nombre, usuarioId);
            return NoContent();
        }

        [HttpPost("desactivar")]
        public async Task<IActionResult> Desactivar([FromQuery] int productoId, [FromQuery] int usuarioId)
        {
            await _service.DesactivarAsync(productoId, usuarioId);
            return NoContent();
        }

        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromQuery] int productoId, [FromQuery] int usuarioId)
        {
            await _service.ActivarAsync(productoId, usuarioId);
            return NoContent();
        }

        [HttpGet("activos")]
        public async Task<IActionResult> MostrarActivos() => Ok(await _service.MostrarActivosAsync());

        [HttpGet("activos/{productoId:int}")]
        public async Task<IActionResult> MostrarActivosPorId(int productoId) => Ok(await _service.MostrarActivosPorIdAsync(productoId));

        [HttpGet("activos/buscar")]
        public async Task<IActionResult> MostrarActivosPorNombre([FromQuery] string nombre) => Ok(await _service.MostrarActivosPorNombreAsync(nombre));

        [HttpGet("inactivos")]
        public async Task<IActionResult> MostrarInactivos([FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosAsync(usuarioId));

        [HttpGet("inactivos/{productoId:int}")]
        public async Task<IActionResult> MostrarInactivosPorId(int productoId, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorIdAsync(productoId, usuarioId));

        [HttpGet("inactivos/buscar")]
        public async Task<IActionResult> MostrarInactivosPorNombre([FromQuery] string nombre, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorNombreAsync(nombre, usuarioId));
    }
}


