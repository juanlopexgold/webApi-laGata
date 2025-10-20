using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.Entities;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using LaGata.Api.DTOs;

namespace LaGata.Api.Services.Implementations
{
    public class SeguridadService : ISeguridadService
    {
        private readonly LaGataDbContext _context;
        public SeguridadService(LaGataDbContext context) => _context = context;

        public async Task<Usuario?> LoginAsync(string email, string passwordHash)
        {
            var rows = _context.Set<LoginUsuarioDto>()
                .FromSqlRaw("EXEC sp_LoginUsuario @p0, @p1", email, passwordHash)
                .AsEnumerable()
                .ToList();

            var dto = rows.FirstOrDefault();
            if (dto == null) return null;

            return new Usuario
            {
                UsuarioId = dto.UsuarioId,
                Username = dto.Username,
                Nombre = dto.Nombre,
                Email = dto.Email,
                RolId = dto.RolId,
                Activo = true
            };
        }

        public async Task RegistrarAsync(Usuario nuevoUsuario)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_RegistrarUsuario @p0, @p1, @p2, @p3, @p4, @p5, @p6",
                nuevoUsuario.Username,
                nuevoUsuario.Nombre,
                nuevoUsuario.Email,
                nuevoUsuario.PasswordHash,
                nuevoUsuario.RolId,
                nuevoUsuario.Telefono,
                nuevoUsuario.UsuarioId // creador
            );
        }

        public async Task<IEnumerable<UsuarioRolDto>> VerRolUsuarioAsync(int usuarioId)
        {
            return _context.Set<UsuarioRolDto>().FromSqlRaw(
                "EXEC sp_VerRolUsuario @p0", usuarioId).AsEnumerable().ToList();
        }

        public async Task AsignarRolUsuarioAsync(int usuarioId, int nuevoRolId, int usuarioAdminId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_AsignarRolUsuario @p0, @p1, @p2",
                usuarioId, nuevoRolId, usuarioAdminId);
        }

        public async Task DesactivarUsuarioAsync(int usuarioId, int usuarioAdminId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Usuario_Desactivar @p0, @p1",
                usuarioId, usuarioAdminId);
        }

        public async Task ActivarUsuarioAsync(int usuarioId, int usuarioAdminId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Usuario_Activar @p0, @p1",
                usuarioId, usuarioAdminId);
        }

        public async Task<IEnumerable<UsuarioAdminListadoDto>> ListarUsuariosActivosAsync(int usuarioAdminId)
        {
            return _context.Set<UsuarioAdminListadoDto>().FromSqlRaw(
                "EXEC sp_Usuarios_MostrarActivos @p0", usuarioAdminId).AsEnumerable().ToList();
        }

        public async Task<IEnumerable<UsuarioAdminListadoDto>> ListarUsuariosInactivosAsync(int usuarioAdminId)
        {
            return _context.Set<UsuarioAdminListadoDto>().FromSqlRaw(
                "EXEC sp_Usuarios_MostrarInactivos @p0", usuarioAdminId).AsEnumerable().ToList();
        }

        public async Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosTodosAsync()
        {
            return _context.Set<UsuarioResumenDto>().FromSqlRaw(
                "EXEC sp_Usuarios_MostrarTodos").AsEnumerable().ToList();
        }

        public async Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosActivosInfoAsync()
        {
            return _context.Set<UsuarioResumenDto>().FromSqlRaw(
                "EXEC sp_Usuarios_MostrarActivosInfo").AsEnumerable().ToList();
        }

        public async Task<IEnumerable<UsuarioResumenDto>> ListarUsuariosInactivosInfoAsync()
        {
            return _context.Set<UsuarioResumenDto>().FromSqlRaw(
                "EXEC sp_Usuarios_MostrarInactivosInfo").AsEnumerable().ToList();
        }

        public async Task<IEnumerable<UsuarioResumenDto>> VerUsuarioPorIdAsync(int usuarioId)
        {
            return _context.Set<UsuarioResumenDto>().FromSqlRaw(
                "EXEC sp_Usuario_MostrarPorId @p0", usuarioId).AsEnumerable().ToList();
        }
    }
}