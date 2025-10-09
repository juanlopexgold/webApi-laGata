using System;

namespace LaGata.Api.DTOs
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}


