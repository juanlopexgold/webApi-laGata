using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaGata.Api.DTOs;

namespace LaGata.Api.Interfaces
{
    public interface ICompraService
    {
        // Operaciones CRUD básicas
        Task<CompraResponse> CrearCompraAsync(CrearCompraRequest request);
        Task<CompraResponse> ObtenerCompraCompletaAsync(int compraId);
        Task<bool> AnularCompraAsync(AnularCompraRequest request);
        
        // Listados y consultas
        Task<IEnumerable<CompraListResponse>> ListarTodasAsync(int usuarioId);
        Task<IEnumerable<CompraListResponse>> ListarPorFechasAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId);
        Task<IEnumerable<CompraListResponse>> ListarPorProveedorAsync(int proveedorId, int usuarioId);
        Task<IEnumerable<CompraListResponse>> ListarConFiltrosAsync(CompraFiltrosRequest filtros, int usuarioId);
        
        // Reportes y estadísticas
        Task<CompraResumenResponse> ObtenerResumenPeriodoAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId);
        Task<IEnumerable<TopProductoCompradoResponse>> ObtenerTopProductosAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId);
        
        // Validaciones
        Task<bool> ValidarPermisosAsync(int usuarioId);
        Task<bool> ExisteCompraAsync(int compraId);
    }
}
