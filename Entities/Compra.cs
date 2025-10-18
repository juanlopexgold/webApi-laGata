using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaGata.Api.Entities
{
    [Table("Compras")]
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }
        
        [Required]
        public int ProveedorId { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        
        [StringLength(500)]
        public string Observaciones { get; set; }
        
        [Required]
        public DateTime FechaCompra { get; set; }
        
        [Required]
        public bool Activo { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }
        
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        
        public virtual ICollection<DetalleCompra> DetallesCompra { get; set; } = new List<DetalleCompra>();
    }
}
