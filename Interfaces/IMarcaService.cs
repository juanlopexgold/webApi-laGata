using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface IMarcaService
    {
        Task CrearAsync(string nombre, int usuarioId);
        Task EditarAsync(int marcaId, string nombre, int usuarioId);
        Task DesactivarAsync(int marcaId, int usuarioId);
        Task ActivarAsync(int marcaId, int usuarioId);

        Task<IEnumerable<MarcaDto>> MostrarActivosAsync();
        Task<IEnumerable<MarcaDto>> MostrarActivosPorIdAsync(int marcaId);
        Task<IEnumerable<MarcaDto>> MostrarActivosPorNombreAsync(string nombre);

        Task<IEnumerable<MarcaDto>> MostrarInactivosAsync(int usuarioId);
        Task<IEnumerable<MarcaDto>> MostrarInactivosPorIdAsync(int marcaId, int usuarioId);
        Task<IEnumerable<MarcaDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId);
    }
}


