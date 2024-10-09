using System;
using System.Text;
namespace reportesApi.Models
{
    public class GetDetalleOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdOredenCompra { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal CantidadRecibida { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoRenglon { get; set; }
        public string UsuarioRegistra { get; set; }


    }

    public class InsertDetalleOrdenCompraModel 
    {
        public int IdOredenCompra { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal CantidadRecibida { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoRenglon { get; set; }
        public int UsuarioRegistra {get; set;}

       
    }

    public class UpdateDetalleOrdenCompraModel
    {
        public int Id { get; set; }
        public int IdOredenCompra { get; set; }
        public string Insumo{ get; set; }
        public decimal Cantidad {get; set;}
        public decimal CantidadRecibida { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoRenglon { get; set; }
        public int UsuarioRegistra {get; set;}
    }

}