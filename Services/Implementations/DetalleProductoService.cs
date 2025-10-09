using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class DetalleProductoService : IDetalleProductoService
    {
        private readonly LaGataDbContext _context;
        public DetalleProductoService(LaGataDbContext context) => _context = context;

        public async Task<IEnumerable<DetalleProductoDto>> MostrarActivosAsync()
        {
            return await _context.Set<DetalleProductoDto>().FromSqlRaw("EXEC sp_DetalleProducto_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<DetalleProductoDto>> MostrarPorIdAsync(int detalleProductoId)
        {
            return await _context.Set<DetalleProductoDto>().FromSqlRaw("EXEC sp_DetalleProducto_MostrarPorId @p0", detalleProductoId).ToListAsync();
        }

        public async Task<IEnumerable<DetalleProductoDto>> MostrarPorNombreAsync(string nombre)
        {
            return await _context.Set<DetalleProductoDto>().FromSqlRaw("EXEC sp_DetalleProducto_MostrarPorNombre @p0", nombre).ToListAsync();
        }

        public async Task AjustarStockAsync(int detalleProductoId, int cantidad, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DetalleProducto_AjustarStock @p0, @p1, @p2", detalleProductoId, cantidad, usuarioId);
        }
    }
}


