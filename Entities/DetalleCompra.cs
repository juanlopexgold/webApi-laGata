using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaGata.Api.Entities
{
    [Table("DetalleCompra")]
    public class DetalleCompra
    {
        [Key]
        public int DetalleCompraId { get; set; }
        
        [Required]
        public int CompraId { get; set; }
        
        [Required]
        public int DetalleProductoId { get; set; }
        
        [StringLength(50)]
        public string CodigoBarra { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("CompraId")]
        public virtual Compra Compra { get; set; }
        
        [ForeignKey("DetalleProductoId")]
        public virtual DetalleProducto DetalleProducto { get; set; }
    }
}
