using System;
namespace reportesApi.Models
{
    public class GetRecetasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estatus{ get; set; }
        public string FechaCreacion {get; set;}
        public string FechaInicio {get; set;}
        public string FechaFinal {get; set;}
        public string UsuarioRegistra { get; set; }   
     }

    public class InsertRecetasModel 
    {
        public string Nombre { get; set; }
        public int Estatus{ get; set; }
        public int UsuarioRegistra {get; set;}
       
    }

    public class UpdateRecetasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Estatus{ get; set; }
        public int UsuarioRegistra {get; set;}
       
    }

}