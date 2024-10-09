using System;
namespace reportesApi.Models
{
    public class GetOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string FechaLlegada{ get; set; }
        public int IdSucursal {get; set;}
        public int IdComprador { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set;}
        public string UsuarioRegistra { get; set; }
    }

    public class InsertOrdenCompraModel 
    {
        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }
        public int IdComprador {get; set;}
        public decimal Total { get; set; }
        public int UsuarioRegistra {get; set;}

    }

    public class UpdateOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal{ get; set; }
        public int IdComprador {get; set;}
        public decimal Total { get; set;}
        public int UsuarioRegistra {get; set;}

    }

}