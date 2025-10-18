using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaGata.Api.Entities
{
    [Table("Proveedores")]
    public class Proveedor
    {
        [Key]
        public int ProveedorId { get; set; }
        
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        
        [StringLength(20)]
        public string Telefono { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(200)]
        public string Direccion { get; set; }
        
        [Required]
        public bool Activo { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
