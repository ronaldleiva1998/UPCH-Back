using System;
using System.Collections.Generic;

namespace pjPruebaUpch.Models
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public int? NumeroTelefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
    }
}
