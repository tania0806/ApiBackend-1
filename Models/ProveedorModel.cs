using System;
using System.Runtime.CompilerServices;
namespace reportesApi.Models
{
    public class GetProveedorModel
    {
        public int IdProveedor { get; set; }
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public int PlazoPago { get; set; }
        public decimal PorcentajeRetencion { get; set;}
        public string Estatus {get; set;}
        public string FechaRegistro { get; set; }
        public string UsuarioRegistra { get; set; }
    }

    public class InsertProveedorModel 
    { 
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public int PlazoPago { get; set; }
        public decimal PorcentajeRetencion { get; set;}
        public int UsuarioRegistra {get; set;}
    
    }

    public class UpdateProveedorModel
    {
       public int IdProveedor { get; set; }
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public int PlazoPago { get; set; }
        public decimal PorcentajeRetencion { get; set;}
        public int UsuarioRegistra {get; set;}
  
    }

}