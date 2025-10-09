using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class ProveedorService : IProveedorService
    {
        private readonly LaGataDbContext _context;
        public ProveedorService(LaGataDbContext context) => _context = context;

        public async Task CrearAsync(string nombre, string telefono, string email, string direccion, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Proveedor_Crear @p0, @p1, @p2, @p3, @p4",
                nombre, telefono, email, direccion, usuarioId);
        }

        public async Task EditarAsync(int proveedorId, string nombre, string telefono, string email, string direccion, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_Proveedor_Editar @p0, @p1, @p2, @p3, @p4, @p5",
                proveedorId, nombre, telefono, email, direccion, usuarioId);
        }

        public async Task DesactivarAsync(int proveedorId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Proveedor_Desactivar @p0, @p1", proveedorId, usuarioId);
        }

        public async Task ActivarAsync(int proveedorId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Proveedor_Activar @p0, @p1", proveedorId, usuarioId);
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarActivosAsync()
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarActivosPorIdAsync(int proveedorId)
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarActivosPorId @p0", proveedorId).ToListAsync();
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarActivosPorNombreAsync(string nombre)
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarActivosPorNombre @p0", nombre).ToListAsync();
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarInactivosAsync(int usuarioId)
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarInactivos @p0", usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarInactivosPorIdAsync(int proveedorId, int usuarioId)
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarInactivosPorId @p0, @p1", proveedorId, usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ProveedorDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId)
        {
            return await _context.Set<ProveedorDto>().FromSqlRaw("EXEC sp_Proveedor_MostrarInactivosPorNombre @p0, @p1", nombre, usuarioId).ToListAsync();
        }
    }
}


