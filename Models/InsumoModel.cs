using System;
namespace reportesApi.Models
{
    public class GetInsumoModel
    {
        public int IdInsumo { get; set; }
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }
        public string Estatus { get; set; }
        public string FechaRegistro { get; set; }
        public string UsuarioRegistra { get; set; }
    }

    public class InsertInsumoModel 
    {
        
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }
        public int UsuarioRegistra {get; set;}

    }

    public class UpdateInsumoModel
    {
       
        public int IdInsumo { get; set; }
        public string Insumo{ get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Costo { get; set; }
        public int UnidadMedida { get; set; }
        public string InsumoUp { get; set; }
        public int UsuarioRegistra {get; set;}
       
    }

}