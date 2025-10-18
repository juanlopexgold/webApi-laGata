using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaGata.Api.Data;
using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace LaGata.Api.Services.Implementations
{
    public class CompraService : ICompraService
    {
        private readonly LaGataDbContext _context;

        public CompraService(LaGataDbContext context)
        {
            _context = context;
        }

        public async Task<CompraResponse> CrearCompraAsync(CrearCompraRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Crear la compra (maestro)
                var compraIdParam = new SqlParameter("@CompraId", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_Compra_Crear @ProveedorId, @UsuarioId, @Total, @Observaciones, @CompraId OUTPUT",
                    new SqlParameter("@ProveedorId", request.ProveedorId),
                    new SqlParameter("@UsuarioId", request.UsuarioId),
                    new SqlParameter("@Total", request.Total),
                    new SqlParameter("@Observaciones", request.Observaciones ?? (object)DBNull.Value),
                    compraIdParam);

                var compraId = (int)compraIdParam.Value;

                // Crear los detalles
                foreach (var detalle in request.Detalles)
                {
                    await _context.Database.ExecuteSqlRawAsync(
                        "EXEC sp_DetalleCompra_Crear @CompraId, @DetalleProductoId, @Cantidad, @PrecioUnitario, @Subtotal",
                        new SqlParameter("@CompraId", compraId),
                        new SqlParameter("@DetalleProductoId", detalle.DetalleProductoId),
                        new SqlParameter("@Cantidad", detalle.Cantidad),
                        new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                        new SqlParameter("@Subtotal", detalle.Subtotal));
                }

                await transaction.CommitAsync();

                // Retornar la compra completa
                return await ObtenerCompraCompletaAsync(compraId);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CompraResponse> ObtenerCompraCompletaAsync(int compraId)
        {
            var compra = await _context.Set<CompraResponse>()
                .FromSqlRaw("EXEC sp_Compra_ObtenerCompleta @CompraId", new SqlParameter("@CompraId", compraId))
                .FirstOrDefaultAsync();

            if (compra == null)
                return null;

            // Obtener los detalles
            var detalles = await _context.Set<DetalleCompraResponse>()
                .FromSqlRaw("EXEC sp_Compra_ObtenerCompleta @CompraId", new SqlParameter("@CompraId", compraId))
                .ToListAsync();

            compra.Detalles = detalles;
            return compra;
        }

        public async Task<bool> AnularCompraAsync(AnularCompraRequest request)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_Compra_Anular @CompraId, @UsuarioId",
                    new SqlParameter("@CompraId", request.CompraId),
                    new SqlParameter("@UsuarioId", request.UsuarioId));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CompraListResponse>> ListarTodasAsync(int usuarioId)
        {
            return await _context.Set<CompraListResponse>()
                .FromSqlRaw("EXEC sp_Compras_ListarTodas @UsuarioId", new SqlParameter("@UsuarioId", usuarioId))
                .ToListAsync();
        }

        public async Task<IEnumerable<CompraListResponse>> ListarPorFechasAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId)
        {
            return await _context.Set<CompraListResponse>()
                .FromSqlRaw("EXEC sp_Compras_ListarPorFechas @FechaInicio, @FechaFin, @UsuarioId",
                    new SqlParameter("@FechaInicio", fechaInicio),
                    new SqlParameter("@FechaFin", fechaFin),
                    new SqlParameter("@UsuarioId", usuarioId))
                .ToListAsync();
        }

        public async Task<IEnumerable<CompraListResponse>> ListarPorProveedorAsync(int proveedorId, int usuarioId)
        {
            return await _context.Set<CompraListResponse>()
                .FromSqlRaw("EXEC sp_Compras_ListarPorProveedor @ProveedorId, @UsuarioId",
                    new SqlParameter("@ProveedorId", proveedorId),
                    new SqlParameter("@UsuarioId", usuarioId))
                .ToListAsync();
        }

        public async Task<IEnumerable<CompraListResponse>> ListarConFiltrosAsync(CompraFiltrosRequest filtros, int usuarioId)
        {
            var compras = await ListarTodasAsync(usuarioId);

            if (filtros.FechaInicio.HasValue && filtros.FechaFin.HasValue)
            {
                compras = compras.Where(c => c.FechaCompra.Date >= filtros.FechaInicio.Value.Date &&
                                           c.FechaCompra.Date <= filtros.FechaFin.Value.Date);
            }

            if (filtros.ProveedorId.HasValue)
            {
                compras = compras.Where(c => c.ProveedorId == filtros.ProveedorId.Value);
            }

            if (filtros.UsuarioId.HasValue)
            {
                compras = compras.Where(c => c.UsuarioId == filtros.UsuarioId.Value);
            }

            if (filtros.Activo.HasValue)
            {
                compras = compras.Where(c => c.Activo == filtros.Activo.Value);
            }

            return compras;
        }

        public async Task<CompraResumenResponse> ObtenerResumenPeriodoAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId)
        {
            return await _context.Set<CompraResumenResponse>()
                .FromSqlRaw("EXEC sp_Compras_ResumenPeriodo @FechaInicio, @FechaFin, @UsuarioId",
                    new SqlParameter("@FechaInicio", fechaInicio),
                    new SqlParameter("@FechaFin", fechaFin),
                    new SqlParameter("@UsuarioId", usuarioId))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TopProductoCompradoResponse>> ObtenerTopProductosAsync(DateTime fechaInicio, DateTime fechaFin, int usuarioId)
        {
            return await _context.Set<TopProductoCompradoResponse>()
                .FromSqlRaw("EXEC sp_Compras_TopProductos @FechaInicio, @FechaFin, @UsuarioId",
                    new SqlParameter("@FechaInicio", fechaInicio),
                    new SqlParameter("@FechaFin", fechaFin),
                    new SqlParameter("@UsuarioId", usuarioId))
                .ToListAsync();
        }

        public async Task<bool> ValidarPermisosAsync(int usuarioId)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.UsuarioId == usuarioId && u.Activo)
                .FirstOrDefaultAsync();

            return usuario?.RolId == 1; // Solo Admin
        }

        public async Task<bool> ExisteCompraAsync(int compraId)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "SELECT COUNT(*) FROM Compras WHERE CompraId = @CompraId",
                new SqlParameter("@CompraId", compraId)) > 0;
        }
    }
}
