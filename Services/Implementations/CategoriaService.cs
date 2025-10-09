using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaGata.Api.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly LaGataDbContext _context;
        public CategoriaService(LaGataDbContext context) => _context = context;

        public async Task CrearAsync(string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Categoria_Crear @p0, @p1", nombre, usuarioId);
        }

        public async Task EditarAsync(int categoriaId, string nombre, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Categoria_Editar @p0, @p1, @p2", categoriaId, nombre, usuarioId);
        }

        public async Task DesactivarAsync(int categoriaId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Categoria_Desactivar @p0, @p1", categoriaId, usuarioId);
        }

        public async Task ActivarAsync(int categoriaId, int usuarioId)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_Categoria_Activar @p0, @p1", categoriaId, usuarioId);
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarActivosAsync()
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarActivos").ToListAsync();
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarActivosPorIdAsync(int categoriaId)
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarActivosPorId @p0", categoriaId).ToListAsync();
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarActivosPorNombreAsync(string nombre)
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarActivosPorNombre @p0", nombre).ToListAsync();
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarInactivosAsync(int usuarioId)
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarInactivos @p0", usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarInactivosPorIdAsync(int categoriaId, int usuarioId)
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarInactivosPorId @p0, @p1", categoriaId, usuarioId).ToListAsync();
        }

        public async Task<IEnumerable<CategoriaDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId)
        {
            return await _context.Set<CategoriaDto>().FromSqlRaw("EXEC sp_Categoria_MostrarInactivosPorNombre @p0, @p1", nombre, usuarioId).ToListAsync();
        }
    }
}


