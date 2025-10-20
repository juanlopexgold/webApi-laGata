using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LaGata.Api.DTOs
{
    // DTO para crear una nueva compra
    public class CrearCompraRequest
    {
        [Required]
        public int ProveedorId { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        public decimal Total { get; set; }
        
        [StringLength(500)]
        public string Observaciones { get; set; }
        
        [Required]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearDetalleCompraRequest> Detalles { get; set; } = new List<CrearDetalleCompraRequest>();
    }

    // DTO para crear detalle de compra
    public class CrearDetalleCompraRequest
    {
        [Required]
        public int DetalleProductoId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal PrecioUnitario { get; set; }
        
        [StringLength(50)]
        public string CodigoBarra { get; set; }
    }

    // DTO para respuesta de compra
    public class CompraResponse
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public string ProveedorTelefono { get; set; }
        public string ProveedorEmail { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool Activo { get; set; }
        public List<DetalleCompraResponse> Detalles { get; set; } = new List<DetalleCompraResponse>();
    }

    // DTO para respuesta de detalle de compra
    public class DetalleCompraResponse
    {
        public int DetalleCompraId { get; set; }
        public int DetalleProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public string CategoriaNombre { get; set; }
        public string MarcaNombre { get; set; }
        public string CodigoBarra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    // DTO para listar compras
    public class CompraListResponse
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCompra { get; set; }
        public bool Activo { get; set; }
        public int TotalItems { get; set; }
    }

    // DTO para filtros de búsqueda
    public class CompraFiltrosRequest
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? ProveedorId { get; set; }
        public int? UsuarioId { get; set; }
        public bool? Activo { get; set; }
    }

    // DTO para resumen de compras
    public class CompraResumenResponse
    {
        public int TotalCompras { get; set; }
        public decimal TotalMonto { get; set; }
        public decimal PromedioCompra { get; set; }
        public decimal CompraMinima { get; set; }
        public decimal CompraMaxima { get; set; }
    }

    // DTO para top productos comprados
    public class TopProductoCompradoResponse
    {
        public string ProductoNombre { get; set; }
        public string MarcaNombre { get; set; }
        public string CategoriaNombre { get; set; }
        public int TotalCantidad { get; set; }
        public decimal TotalMonto { get; set; }
        public int VecesComprado { get; set; }
    }

    // DTO para anular compra
    public class AnularCompraRequest
    {
        [Required]
        public int CompraId { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
    }
}
