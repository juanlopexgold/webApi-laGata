using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGata.Api.Entities;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface ISeguridadService
    {
        Task<Usuario?> LoginAsync(string email, string passwordHash);
        Task RegistrarAsync(Usuario nuevoUsuario);

        // Stored procedures - queries
        Task<IEnumerable<UsuarioRolDto>> VerRolUsuarioAsync(int usuarioId);
        Task AsignarRolUsuarioAsync(int usuarioId, int nuevoRolId, int usuarioAdminId);
        Task DesactivarUsuarioAsync(int usuarioId, int usuarioAdminId);
        Task ActivarUsuarioAsync(int usuarioId, int usuarioAdminId);
        Task<IEnumerable<UsuarioAdminListadoDto>> ListarUsuariosActivosAsync(int usuarioAdminId);
        Task<IEnumerable<UsuarioAdminListadoDto>> ListarUsuariosInactivosAsync(int usuarioAdminId);
        Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosTodosAsync();
        Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosActivosInfoAsync();
        Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosInactivosInfoAsync();
        Task<IEnumerable<UsuarioResumenDto>> VerUsuarioPorIdAsync(int usuarioId);
    }
}