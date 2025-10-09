using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorService _service;
        public ProveedoresController(IProveedorService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Crear([FromQuery] string nombre, [FromQuery] string telefono, [FromQuery] string email, [FromQuery] string direccion, [FromQuery] int usuarioId)
        {
            await _service.CrearAsync(nombre, telefono, email, direccion, usuarioId);
            return Created(string.Empty, null);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] int proveedorId, [FromQuery] string nombre, [FromQuery] string telefono, [FromQuery] string email, [FromQuery] string direccion, [FromQuery] int usuarioId)
        {
            await _service.EditarAsync(proveedorId, nombre, telefono, email, direccion, usuarioId);
            return NoContent();
        }

        [HttpPost("desactivar")]
        public async Task<IActionResult> Desactivar([FromQuery] int proveedorId, [FromQuery] int usuarioId)
        {
            await _service.DesactivarAsync(proveedorId, usuarioId);
            return NoContent();
        }

        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromQuery] int proveedorId, [FromQuery] int usuarioId)
        {
            await _service.ActivarAsync(proveedorId, usuarioId);
            return NoContent();
        }

        [HttpGet("activos")]
        public async Task<IActionResult> MostrarActivos() => Ok(await _service.MostrarActivosAsync());

        [HttpGet("activos/{proveedorId:int}")]
        public async Task<IActionResult> MostrarActivosPorId(int proveedorId) => Ok(await _service.MostrarActivosPorIdAsync(proveedorId));

        [HttpGet("activos/buscar")]
        public async Task<IActionResult> MostrarActivosPorNombre([FromQuery] string nombre) => Ok(await _service.MostrarActivosPorNombreAsync(nombre));

        [HttpGet("inactivos")]
        public async Task<IActionResult> MostrarInactivos([FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosAsync(usuarioId));

        [HttpGet("inactivos/{proveedorId:int}")]
        public async Task<IActionResult> MostrarInactivosPorId(int proveedorId, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorIdAsync(proveedorId, usuarioId));

        [HttpGet("inactivos/buscar")]
        public async Task<IActionResult> MostrarInactivosPorNombre([FromQuery] string nombre, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorNombreAsync(nombre, usuarioId));
    }
}


