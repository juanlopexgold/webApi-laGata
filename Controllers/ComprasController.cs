using LaGata.Api.DTOs;
using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _service;

        public ComprasController(ICompraService service)
        {
            _service = service;
        }

        // 1. Crear compra
        [HttpPost]
        public async Task<IActionResult> CrearCompra([FromBody] CrearCompraRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var compra = await _service.CrearCompraAsync(request);
                return CreatedAtAction(nameof(ObtenerCompra), new { id = compra.CompraId }, compra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 2. Obtener compra completa
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerCompra(int id)
        {
            try
            {
                var compra = await _service.ObtenerCompraCompletaAsync(id);
                if (compra == null)
                    return NotFound();

                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 3. Listar todas las compras
        [HttpGet]
        public async Task<IActionResult> ListarCompras([FromQuery] int usuarioId)
        {
            try
            {
                var compras = await _service.ListarTodasAsync(usuarioId);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 4. Listar compras por fechas
        [HttpGet("por-fechas")]
        public async Task<IActionResult> ListarPorFechas(
            [FromQuery] DateTime fechaInicio, 
            [FromQuery] DateTime fechaFin, 
            [FromQuery] int usuarioId)
        {
            try
            {
                var compras = await _service.ListarPorFechasAsync(fechaInicio, fechaFin, usuarioId);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 5. Listar compras por proveedor
        [HttpGet("por-proveedor/{proveedorId:int}")]
        public async Task<IActionResult> ListarPorProveedor(int proveedorId, [FromQuery] int usuarioId)
        {
            try
            {
                var compras = await _service.ListarPorProveedorAsync(proveedorId, usuarioId);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 6. Listar compras con filtros
        [HttpPost("filtrar")]
        public async Task<IActionResult> ListarConFiltros([FromBody] CompraFiltrosRequest filtros, [FromQuery] int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var compras = await _service.ListarConFiltrosAsync(filtros, usuarioId);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 7. Anular compra
        [HttpPost("anular")]
        public async Task<IActionResult> AnularCompra([FromBody] AnularCompraRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _service.AnularCompraAsync(request);
                if (resultado)
                    return Ok(new { message = "Compra anulada exitosamente" });
                else
                    return BadRequest(new { message = "No se pudo anular la compra" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 8. Obtener resumen de compras por período
        [HttpGet("resumen")]
        public async Task<IActionResult> ObtenerResumen(
            [FromQuery] DateTime fechaInicio, 
            [FromQuery] DateTime fechaFin, 
            [FromQuery] int usuarioId)
        {
            try
            {
                var resumen = await _service.ObtenerResumenPeriodoAsync(fechaInicio, fechaFin, usuarioId);
                return Ok(resumen);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 9. Obtener top productos comprados
        [HttpGet("top-productos")]
        public async Task<IActionResult> ObtenerTopProductos(
            [FromQuery] DateTime fechaInicio, 
            [FromQuery] DateTime fechaFin, 
            [FromQuery] int usuarioId)
        {
            try
            {
                var topProductos = await _service.ObtenerTopProductosAsync(fechaInicio, fechaFin, usuarioId);
                return Ok(topProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // 10. Validar permisos
        [HttpGet("validar-permisos/{usuarioId:int}")]
        public async Task<IActionResult> ValidarPermisos(int usuarioId)
        {
            try
            {
                var tienePermisos = await _service.ValidarPermisosAsync(usuarioId);
                return Ok(new { tienePermisos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
