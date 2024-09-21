using System;
namespace reportesApi.Models
{
    public class GetAlumnoModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre{ get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public string Estatus { get; set; }
        public string UsuarioRegistra { get; set; }
        public string FechaRegistro { get; set; }
    }

    public class InsertAlumnoModel 
    {
        public string Matricula { get; set; }
        public string Nombre{ get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
    }

    public class UpdateAlumnoModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre{ get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
    }

}