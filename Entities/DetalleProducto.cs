using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaGata.Api.Entities
{
    [Table("DetalleProducto")]
    public class DetalleProducto
    {
        [Key]
        public int DetalleProductoId { get; set; }
        
        [Required]
        public int ProductoId { get; set; }
        
        [Required]
        public int CategoriaId { get; set; }
        
        [Required]
        public int MarcaId { get; set; }
        
        [StringLength(50)]
        public string CodigoBarra { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        
        [Required]
        public int Stock { get; set; }
        
        [Required]
        public DateTime FechaCreacion { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
        
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        
        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }
        
        public virtual ICollection<DetalleCompra> DetallesCompra { get; set; } = new List<DetalleCompra>();
    }
}
