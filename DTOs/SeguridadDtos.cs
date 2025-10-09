using System;

namespace LaGata.Api.DTOs
{
    public class LoginUsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }

    public class UsuarioRolDto
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string NombreRol { get; set; }
    }

    public class UsuarioAdminListadoDto
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NombreRol { get; set; }
        public bool Activo { get; set; }
    }

    public class UsuarioResumenDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public string Rol { get; set; }
    }
}


