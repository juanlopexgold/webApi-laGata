using LaGata.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LaGata.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleProductosController : ControllerBase
    {
        private readonly IDetalleProductoService _service;
        public DetalleProductosController(IDetalleProductoService service) => _service = service;

        [HttpGet("activos")]
        public async Task<IActionResult> Activos() => Ok(await _service.MostrarActivosAsync());

        [HttpGet("{detalleProductoId:int}")]
        public async Task<IActionResult> PorId(int detalleProductoId) => Ok(await _service.MostrarPorIdAsync(detalleProductoId));

        [HttpGet("buscar")]
        public async Task<IActionResult> PorNombre([FromQuery] string nombre) => Ok(await _service.MostrarPorNombreAsync(nombre));

        [HttpPost("ajustar-stock")]
        public async Task<IActionResult> AjustarStock([FromQuery] int detalleProductoId, [FromQuery] int cantidad, [FromQuery] int usuarioId)
        {
            await _service.AjustarStockAsync(detalleProductoId, cantidad, usuarioId);
            return NoContent();
        }
    }
}


