using System;
namespace reportesApi.Models
{
    public class GetAlmacenModel
    {
        public int IdAlmacen { get; set; }
        public string Nombre{ get; set; }
        public string Direccion {get; set;}
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioRegistra { get; set; }

    }

    public class InsertAlmacenModel 
    {
        public string Nombre{ get; set; }
        public string Direccion {get; set;}
        public int UsuarioRegistra {get; set;}
       
    }

    public class UpdateAlmacenModel
    {
        public int IdAlmacen { get; set; }
        public string Nombre{ get; set; }
        public string Direccion {get; set;}
        public int UsuarioRegistra {get; set;}

       
    }

}