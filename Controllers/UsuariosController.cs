using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ISeguridadService _service;
        public UsuariosController(ISeguridadService service) => _service = service;

        [HttpGet("rol/{usuarioId:int}")]
        public async Task<IActionResult> VerRolUsuario(int usuarioId)
            => Ok(await _service.VerRolUsuarioAsync(usuarioId));

        [HttpPost("asignar-rol")]
        public async Task<IActionResult> AsignarRol([FromQuery] int usuarioId, [FromQuery] int nuevoRolId, [FromQuery] int usuarioAdminId)
        {
            await _service.AsignarRolUsuarioAsync(usuarioId, nuevoRolId, usuarioAdminId);
            return NoContent();
        }

        [HttpPost("desactivar")]
        public async Task<IActionResult> Desactivar([FromQuery] int usuarioId, [FromQuery] int usuarioAdminId)
        {
            await _service.DesactivarUsuarioAsync(usuarioId, usuarioAdminId);
            return NoContent();
        }

        [HttpPost("activar")]
        public async Task<IActionResult> Activar([FromQuery] int usuarioId, [FromQuery] int usuarioAdminId)
        {
            await _service.ActivarUsuarioAsync(usuarioId, usuarioAdminId);
            return NoContent();
        }

        [HttpGet("activos")]
        public async Task<IActionResult> ListarActivos([FromQuery] int usuarioAdminId)
            => Ok(await _service.ListarUsuariosActivosAsync(usuarioAdminId));

        [HttpGet("inactivos")]
        public async Task<IActionResult> ListarInactivos([FromQuery] int usuarioAdminId)
            => Ok(await _service.ListarUsuariosInactivosAsync(usuarioAdminId));

        [HttpGet("todos")]
        public async Task<IActionResult> ListarTodos()
            => Ok(await _service.ListarUsuariosTodosAsync());

        [HttpGet("activos/info")]
        public async Task<IActionResult> ActivosInfo()
            => Ok(await _service.ListarUsuariosActivosInfoAsync());

        [HttpGet("inactivos/info")]
        public async Task<IActionResult> InactivosInfo()
            => Ok(await _service.ListarUsuariosInactivosInfoAsync());

        [HttpGet("{usuarioId:int}")]
        public async Task<IActionResult> VerPorId(int usuarioId)
            => Ok(await _service.VerUsuarioPorIdAsync(usuarioId));
    }
}


