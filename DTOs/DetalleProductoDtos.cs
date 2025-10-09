using System;

namespace LaGata.Api.DTOs
{
    public class DetalleProductoDto
    {
        public int DetalleProductoId { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string CodigoBarra { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}


