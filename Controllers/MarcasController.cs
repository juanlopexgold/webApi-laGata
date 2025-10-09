using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _service;
        public MarcasController(IMarcaService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.CrearAsync(nombre, usuarioId);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] int marcaId, [FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.EditarAsync(marcaId, nombre, usuarioId);
            return NoContent();
        }

        [HttpPost("desactivar")]
        public async Task<IActionResult> Desactivar([FromQuery] int marcaId, [FromQuery] int usuarioId)
        {
            await _service.DesactivarAsync(marcaId, usuarioId);
            return NoContent();
        }

        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromQuery] int marcaId, [FromQuery] int usuarioId)
        {
            await _service.ActivarAsync(marcaId, usuarioId);
            return NoContent();
        }

        [HttpGet("activos")]
        public async Task<IActionResult> MostrarActivos() => Ok(await _service.MostrarActivosAsync());

        [HttpGet("activos/{marcaId:int}")]
        public async Task<IActionResult> MostrarActivosPorId(int marcaId) => Ok(await _service.MostrarActivosPorIdAsync(marcaId));

        [HttpGet("activos/buscar")]
        public async Task<IActionResult> MostrarActivosPorNombre([FromQuery] string nombre) => Ok(await _service.MostrarActivosPorNombreAsync(nombre));

        [HttpGet("inactivos")]
        public async Task<IActionResult> MostrarInactivos([FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosAsync(usuarioId));

        [HttpGet("inactivos/{marcaId:int}")]
        public async Task<IActionResult> MostrarInactivosPorId(int marcaId, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorIdAsync(marcaId, usuarioId));

        [HttpGet("inactivos/buscar")]
        public async Task<IActionResult> MostrarInactivosPorNombre([FromQuery] string nombre, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorNombreAsync(nombre, usuarioId));
    }
}


