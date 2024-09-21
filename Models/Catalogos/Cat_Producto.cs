using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Producto
    {

        public int Producto_Id { get; set; }
        public int Producto_Categorias_Id { get; set; }
        public string Producto { get; set; }
        public int Producto_Tipo { get; set; }
        public int Producto_Tipo_Categoria { get; set; }
        public string Producto_Region { get; set; }
        public double Producto_Costo { get; set; }
        public int Producto_Moneda_Id { get; set; }
        public bool Producto_Estatus { get; set; }
        public string Producto_Sicid { get; set; }
        public string pUltima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_ProductoParams
    {

        public int Producto_Id { get; set; }
       
    }

    public class Cat_ProductoGet
    {

        public int Producto_Id { get; set; }
        public string Producto_Categorias_Id { get; set; }
        public string Producto { get; set; }
        public int Producto_Tipo { get; set; }
        public int Producto_Tipo_Categoria { get; set; }
        public string Producto_Region { get; set; }
        public double Producto_Costo { get; set; }
        public string Producto_Moneda_Id { get; set; }
        public bool Producto_Estatus { get; set; }
        public string Producto_Sicid { get; set; }
        public string pUltima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }

    }


}
