using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface IDetalleProductoService
    {
        Task<IEnumerable<DetalleProductoDto>> MostrarActivosAsync();
        Task<IEnumerable<DetalleProductoDto>> MostrarPorIdAsync(int detalleProductoId);
        Task<IEnumerable<DetalleProductoDto>> MostrarPorNombreAsync(string nombre);
        Task AjustarStockAsync(int detalleProductoId, int cantidad, int usuarioId);
    }
}


