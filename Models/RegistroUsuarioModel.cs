using System;
namespace reportesApi.Models
{
    public class GetRegistroUsuarioModel
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string Apellidos{ get; set; }
        public string Direccion {get; set;}
        public string Correo {get; set;}
        public string Contraseña {get; set;}
        public string Token {get; set;}
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
    }

    public class InsertRegistroUsuarioModel
    {
        public string PrimerNombre { get; set; }
        public string Apellidos{ get; set; }
        public string Direccion {get; set;}
        public string Correo {get; set;}
        public string Contraseña {get; set;}
       
    }

  

}