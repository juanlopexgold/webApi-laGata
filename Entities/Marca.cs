using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaGata.Api.Entities
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        public bool Activo { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<DetalleProducto> DetallesProducto { get; set; } = new List<DetalleProducto>();
    }
}
