using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface IProveedorService
    {
        Task CrearAsync(string nombre, string telefono, string email, string direccion, int usuarioId);
        Task EditarAsync(int proveedorId, string nombre, string telefono, string email, string direccion, int usuarioId);
        Task DesactivarAsync(int proveedorId, int usuarioId);
        Task ActivarAsync(int proveedorId, int usuarioId);

        Task<IEnumerable<ProveedorDto>> MostrarActivosAsync();
        Task<IEnumerable<ProveedorDto>> MostrarActivosPorIdAsync(int proveedorId);
        Task<IEnumerable<ProveedorDto>> MostrarActivosPorNombreAsync(string nombre);

        Task<IEnumerable<ProveedorDto>> MostrarInactivosAsync(int usuarioId);
        Task<IEnumerable<ProveedorDto>> MostrarInactivosPorIdAsync(int proveedorId, int usuarioId);
        Task<IEnumerable<ProveedorDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId);
    }
}


