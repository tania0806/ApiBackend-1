using System;
namespace reportesApi.Models
{
    public class GetDetalleEntadaModel
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public int IdInsumo { get; set;}
        public string Insumo { get; set; }
        public string DescripcionInsumo { get; set; }
        public decimal Cantidad {get; set;}
        public decimal SinCargo { get; set; }
        public decimal Costo {get; set;}
 
        public string Estatus { get; set; }
        public decimal CostoTotal { get; set;}
    }

    public class InsertDetalleEntradaModel 
    {
        public int IdEntrada { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal Costo {get; set;}

       
    }

    public class UpdateDetalleEntradaModel
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal SinCargo {get; set;}
        public decimal Costo {get; set;}

       
    }

    public class DeleteDetalleEntradaModel
        {
            public int Id { get; set; }
        
        }
}