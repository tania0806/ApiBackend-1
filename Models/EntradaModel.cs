using System;
namespace reportesApi.Models
{
    public class GetEntradaModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }
        public decimal Total {get; set;}
        public string Estatus { get; set; }
        public string FechaEntrada { get; set; }
        public string UsuarioRegistra { get; set; }

    }

    public class InsertEntradaModel 
    {
        public int IdProveedor { get; set; }
        public int IdSucursal{ get; set; }
        public decimal Total {get; set;}
        public int UsuarioRegistra {get; set;}
       
    }

    public class UpdateEntradaModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal{ get; set; }
        public decimal Total {get; set;}
        public int UsuarioRegistra {get; set;}
       
    }

    
}