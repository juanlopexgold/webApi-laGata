using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface IClienteService
    {
        Task CrearAsync(string nombre, string telefono, string email, string direccion, int usuarioId);
        Task EditarAsync(int clienteId, string nombre, string telefono, string email, string direccion, int usuarioId);
        Task DesactivarAsync(int clienteId, int usuarioId);
        Task ActivarAsync(int clienteId, int usuarioId);

        Task<IEnumerable<ClienteDto>> MostrarActivosAsync();
        Task<IEnumerable<ClienteDto>> MostrarActivosPorIdAsync(int clienteId);
        Task<IEnumerable<ClienteDto>> MostrarActivosPorNombreAsync(string nombre);

        Task<IEnumerable<ClienteDto>> MostrarInactivosAsync(int usuarioId);
        Task<IEnumerable<ClienteDto>> MostrarInactivosPorIdAsync(int clienteId, int usuarioId);
        Task<IEnumerable<ClienteDto>> MostrarInactivosPorNombreAsync(string nombre, int usuarioId);
    }
}


