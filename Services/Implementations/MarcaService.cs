using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class MarcaService : IMarcaService
    {
        private readonly LaGataDbContext _context;
        public MarcaService(LaGataDbContext context) => _context = context;

        public async Task CrearAsync(string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Marca_Crear @p0, @p1", nombre, usuarioId);
        }

        public async Task EditarAsync(int marcaId, string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Marca_Editar @p0, @p1, @p2", marcaId, nombre, usuarioId);
        }

        public async Task DesactivarAsync(int marcaId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Marca_Desactivar @p0, @p1", marcaId, usuarioId);
        }

        public async Task ActivarAsync(int marcaId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Marca_Activar @p0, @p1", marcaId, usuarioId);
        }

        public async Task<IEnumerable<MarcaDto>> MostrarActivosAsync()
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<MarcaDto>> MostrarActivosPorIdAsync(int marcaId)
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarActivosPorId @p0", marcaId).ToListAsync();
        }

        public async Task<IEnumerable<MarcaDto>> MostrarActivosPorNombreAsync(string nombre)
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarActivosPorNombre @p0", nombre).ToListAsync();
        }

        public async Task<IEnumerable<MarcaDto>> MostrarInactivosAsync(int usuarioId)
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarInactivos @p0", usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<MarcaDto>> MostrarInactivosPorIdAsync(int marcaId, int usuarioId)
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarInactivosPorId @p0, @p1", marcaId, usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<MarcaDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId)
        {
            return await _context.Set<MarcaDto>().FromSqlRaw("EXEC sp_Marca_MostrarInactivosPorNombre @p0, @p1", nombre, usuarioId).ToListAsync();
        }
    }
}


