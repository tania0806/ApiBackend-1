using System;
namespace reportesApi.Models
{
    public class GetDetalleEntradaModel
    {

    public int Id { get; set; }
    public int IdEntrada { get; set; }
    public string Insumo { get; set; }
    public string DescripcionInsumo { get; set; }


    public int Cantidad { get; set; }
    public decimal Costo { get; set; }
    public int Estatus { get; set; }
    public string UsuarioRegistra { get; set; }


    }

    public class InsertDetalleEntradaModel 
    {
        public int IdEntrada { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal Costo {get; set;}
        public int UsuarioRegistra {get; set;}

       
    }

    public class UpdateDetalleEntradaModel
    {
        public int Id { get; set; }
        public int IdEntrada { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal SinCargo {get; set;}
        public decimal Costo {get; set;}
        public int UsuarioRegistra {get; set;}

       
    }

  
}