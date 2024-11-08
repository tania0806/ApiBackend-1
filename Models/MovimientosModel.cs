using System;
namespace reportesApi.Models
{
    public class GetMovimientosModel
    {
        public int Id { get; set; }
        public int IdTiposMovimeinto { get; set; }
        public string Nombre {get; set;}
        public int IdAlmacen { get; set; }
        public string Fecha{ get; set; }
        public int Estatus {get; set;}
        public string Fecha_registro { get; set; }
        public int IdUsuario { get; set; }
    }

    public class InsertMovimientosModel
    {
        public int IdTiposMovimeinto { get; set; }
        public int IdAlmacen { get; set; }
        public int IdUsuario {get; set;}

    }

    public class UpdateMovimientosModel
    {
        public int Id { get; set; }
        public int IdTiposMovimeinto { get; set; }
        public int IdAlmacen { get; set; }
        public int IdUsuario {get; set;}

    }

}