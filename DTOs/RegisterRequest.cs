using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaGata.Api.DTOs
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Telefono { get; set; }
        public int RolId { get; set; }
        public int UsuarioCreadorId { get; set; }
    }
}