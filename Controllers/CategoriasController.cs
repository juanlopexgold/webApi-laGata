using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriasController(ICategoriaService service) => _service = service;

        // 1. Crear
        [HttpPost]
        public async Task<IActionResult> Crear([FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.CrearAsync(nombre, usuarioId);
            return Created(string.Empty, null);
        }

        // 2. Editar
        [HttpPut]
        public async Task<IActionResult> Editar([FromQuery] int categoriaId, [FromQuery] string nombre, [FromQuery] int usuarioId)
        {
            await _service.EditarAsync(categoriaId, nombre, usuarioId);
            return NoContent();
        }

        // 3. Desactivar
        [HttpPost("desactivar")]
        public async Task<IActionResult> Desactivar([FromQuery] int categoriaId, [FromQuery] int usuarioId)
        {
            await _service.DesactivarAsync(categoriaId, usuarioId);
            return NoContent();
        }

        // 4. Activar
        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromQuery] int categoriaId, [FromQuery] int usuarioId)
        {
            await _service.ActivarAsync(categoriaId, usuarioId);
            return NoContent();
        }

        // 5. Activos
        [HttpGet("activos")]
        public async Task<IActionResult> MostrarActivos() => Ok(await _service.MostrarActivosAsync());

        // 6. Activo por Id
        [HttpGet("activos/{categoriaId:int}")]
        public async Task<IActionResult> MostrarActivosPorId(int categoriaId) => Ok(await _service.MostrarActivosPorIdAsync(categoriaId));

        // 7. Activos por Nombre
        [HttpGet("activos/buscar")]
        public async Task<IActionResult> MostrarActivosPorNombre([FromQuery] string nombre) => Ok(await _service.MostrarActivosPorNombreAsync(nombre));

        // 8. Inactivos (admin)
        [HttpGet("inactivos")]
        public async Task<IActionResult> MostrarInactivos([FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosAsync(usuarioId));

        // 9. Inactivo por Id (admin)
        [HttpGet("inactivos/{categoriaId:int}")]
        public async Task<IActionResult> MostrarInactivosPorId(int categoriaId, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorIdAsync(categoriaId, usuarioId));

        // 10. Inactivos por Nombre (admin)
        [HttpGet("inactivos/buscar")]
        public async Task<IActionResult> MostrarInactivosPorNombre([FromQuery] string nombre, [FromQuery] int usuarioId) => Ok(await _service.MostrarInactivosPorNombreAsync(nombre, usuarioId));
    }
}


