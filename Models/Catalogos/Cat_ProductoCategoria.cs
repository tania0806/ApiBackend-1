using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_ProductoCategoria
    {
        public int ProductoCategoria_Id { get; set; }
        public string ProductoCategoria { get; set; }

        public string Ultima_Modificacion { get; set; }

        public string Producto_Categoria_Sicid { get; set; }
        public bool Producto_Categoria_Estatus { get; set; }
        
        
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_ProductoCategoriaParam
    {
        public int ProductoCategoria_Id { get; set; }
       
    }
}
