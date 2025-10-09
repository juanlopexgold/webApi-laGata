using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly LaGataDbContext _context;
        public ProductoService(LaGataDbContext context) => _context = context;

        public async Task CrearAsync(string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Producto_Crear @p0, @p1", nombre, usuarioId);
        }

        public async Task EditarAsync(int productoId, string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Producto_Editar @p0, @p1, @p2", productoId, nombre, usuarioId);
        }

        public async Task DesactivarAsync(int productoId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Producto_Desactivar @p0, @p1", productoId, usuarioId);
        }

        public async Task ActivarAsync(int productoId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Producto_Activar @p0, @p1", productoId, usuarioId);
        }

        public async Task<IEnumerable<ProductoDto>> MostrarActivosAsync()
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<ProductoDto>> MostrarActivosPorIdAsync(int productoId)
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarActivosPorId @p0", productoId).ToListAsync();
        }

        public async Task<IEnumerable<ProductoDto>> MostrarActivosPorNombreAsync(string nombre)
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarActivosPorNombre @p0", nombre).ToListAsync();
        }

        public async Task<IEnumerable<ProductoDto>> MostrarInactivosAsync(int usuarioId)
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarInactivos @p0", usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ProductoDto>> MostrarInactivosPorIdAsync(int productoId, int usuarioId)
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarInactivosPorId @p0, @p1", productoId, usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<ProductoDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId)
        {
            return await _context.Set<ProductoDto>().FromSqlRaw("EXEC sp_Producto_MostrarInactivosPorNombre @p0, @p1", nombre, usuarioId).ToListAsync();
        }
    }
}


