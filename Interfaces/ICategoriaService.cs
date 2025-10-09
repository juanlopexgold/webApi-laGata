using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface ICategoriaService
    {
        Task CrearAsync(string nombre, int usuarioId);
        Task EditarAsync(int categoriaId, string nombre, int usuarioId);
        Task DesactivarAsync(int categoriaId, int usuarioId);
        Task ActivarAsync(int categoriaId, int usuarioId);

        Task<IEnumerable<CategoriaDto>> MostrarActivosAsync();
        Task<IEnumerable<CategoriaDto>> MostrarActivosPorIdAsync(int categoriaId);
        Task<IEnumerable<CategoriaDto>> MostrarActivosPorNombreAsync(string nombre);

        Task<IEnumerable<CategoriaDto>> MostrarInactivosAsync(int usuarioId);
        Task<IEnumerable<CategoriaDto>> MostrarInactivosPorIdAsync(int categoriaId, int usuarioId);
        Task<IEnumerable<CategoriaDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId);
    }
}


