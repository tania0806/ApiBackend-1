using System;
namespace reportesApi.Models
{
    public class GetExtencionesModel
    {

    public int Id { get; set; }
    public string Fecha { get; set; }
    public string Insumo { get; set; }
    public decimal Cantidad { get; set; }
    public int IdAlmacen { get; set; }
    public int Estatus { get; set; }
    public string Fecha_registro { get; set; }
    public string Usuario_registra { get; set; }

    }

    public class InsertExtencionesModel
    {
        
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public int IdAlmacen {get; set;}
        public int Usuario_registra {get; set;}

       
    }

    public class UpdateExtencionesModel
    {
        public int Id { get; set; }
        public int IdAlmacen { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}  
        public int Usuario_registra {get; set;}
       
    }

  
}