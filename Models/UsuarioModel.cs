using System;
namespace reportesApi.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string NombrePersona { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

    }
}
