using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface IProductoService
    {
        Task CrearAsync(string nombre, int usuarioId);
        Task EditarAsync(int productoId, string nombre, int usuarioId);
        Task DesactivarAsync(int productoId, int usuarioId);
        Task ActivarAsync(int productoId, int usuarioId);

        Task<IEnumerable<ProductoDto>> MostrarActivosAsync();
        Task<IEnumerable<ProductoDto>> MostrarActivosPorIdAsync(int productoId);
        Task<IEnumerable<ProductoDto>> MostrarActivosPorNombreAsync(string nombre);

        Task<IEnumerable<ProductoDto>> MostrarInactivosAsync(int usuarioId);
        Task<IEnumerable<ProductoDto>> MostrarInactivosPorIdAsync(int productoId, int usuarioId);
        Task<IEnumerable<ProductoDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId);
    }
}


