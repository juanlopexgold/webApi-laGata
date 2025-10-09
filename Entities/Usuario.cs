using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaGata.Api.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Telefono { get; set; }
        public int RolId { get; set; }
        public bool Activo { get; set; }
    }
}