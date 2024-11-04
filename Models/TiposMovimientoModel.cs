using System;
namespace reportesApi.Models
{
    public class GetTiposMovimientoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EntradaSalida{ get; set; }
         public string TipoMovimiento { get; set; }
        public int Estatus {get; set;}
        public string Fecha_registro { get; set; }
        public string Usuario_registra { get; set; }
    }

    public class InsertTiposMovimientosModel 
    {
        public string Nombre { get; set; }

        public int EntradaSalida{ get; set; }
        public int Usuario_registra {get; set;}

    }

    public class UpdateTiposMovimientosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EntradaSalida{ get; set; }
        public int UsuarioRegistra {get; set;}

    }

}