using System;
namespace reportesApi.Models
{
    public class GetRenglonesMovimientoModel
    {

    public int Id { get; set; }
    public int IdMovimiento { get; set; }
    public string Insumo { get; set; }
    public string DescripcionInsumo { get; set;}
    public decimal Cantidad { get; set; }
    public decimal Costo { get; set; }
    public string TotalCosto {get; set;}
    public int Estatus { get; set; }
    public string Fecha_registro { get; set; }
    public string Usuario_registra { get; set; }
    public string Fechainicial {get; set;}
    public string Fechafinal {get; set;}

    }

    public class InsertRenglonesMovimientoModel
    {
        
        public int IdMovimiento { get; set; }
        public string Insumo { get; set; }
        
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public int Usuario_registra {get; set;}

       
    }

    public class UpdateRenglonesMovimientoModel
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public string Insumo { get; set; }
        public string DescripcionInsumo { get; set;}
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public int Usuario_registra {get; set;}
       
    }

  
}