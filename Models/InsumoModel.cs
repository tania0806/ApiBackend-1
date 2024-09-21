using System;
namespace reportesApi.Models
{
    public class GetInsumoModel
    {
        public int IdInsumo { get; set; }
        public string Usuario { get; set; }
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
    }

    public class InsertInsumoModel 
    {
        
        public string Usuario { get; set; }
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }

    }

    public class UpdateInsumoModel
    {
       
        public int IdInsumo { get; set; }
        public string Usuario { get; set; }
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }
       
    }

}