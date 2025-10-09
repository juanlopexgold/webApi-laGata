using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly LaGataDbContext _context;
        public ClienteService(LaGataDbContext context) => _context = context;

        public async Task CrearAsync(string nombre, string telefono, string email, string direccion, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Cliente_Crear @p0, @p1, @p2, @p3, @p4",
                nombre, telefono, email, direccion, usuarioId);
        }

        public async Task EditarAsync(int clienteId, string nombre, string telefono, string email, string direccion, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Cliente_Editar @p0, @p1, @p2, @p3, @p4, @p5",
                clienteId, nombre, telefono, email, direccion, usuarioId);
        }

        public async Task DesactivarAsync(int clienteId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Cliente_Desactivar @p0, @p1", clienteId, usuarioId);
        }

        public async Task ActivarAsync(int clienteId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Cliente_Activar @p0, @p1", clienteId, usuarioId);
        }

        public async Task<IEnumerable<ClienteDto>> MostrarActivosAsync()
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<ClienteDto>> MostrarActivosPorIdAsync(int clienteId)
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarActivosPorId @p0", clienteId).ToListAsync();
        }

        public async Task<IEnumerable<ClienteDto>> MostrarActivosPorNombreAsync(string nombre)
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarActivosPorNombre @p0", nombre).ToListAsync();
        }

        public async Task<IEnumerable<ClienteDto>> MostrarInactivosAsync(int usuarioId)
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarInactivos @p0", usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ClienteDto>> MostrarInactivosPorIdAsync(int clienteId, int usuarioId)
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarInactivosPorId @p0, @p1", clienteId, usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ClienteDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId)
        {
            return await _context.Set<ClienteDto>().FromSqlRaw("EXEC sp_Cliente_MostrarInactivosPorNombre @p0, @p1", nombre, usuarioId).ToListAsync();
        }
    }
}


