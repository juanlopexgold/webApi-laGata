using LaGata.Api.DTOs;
using LaGata.Api.Entities;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISeguridadService _service;
        public AuthController(ISeguridadService service) => _service = service;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _service.LoginAsync(request.Email, request.PasswordHash);
            return usuario is null ? Unauthorized("Credenciales inválidas") : Ok(usuario);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var nuevoUsuario = new Usuario
            {
                Username = request.Username,
                Nombre = request.Nombre,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                Telefono = request.Telefono,
                RolId = request.RolId,
                UsuarioId = request.UsuarioCreadorId
            };

            await _service.RegistrarAsync(nuevoUsuario);
            return Created("", null);
        }
    }
}
