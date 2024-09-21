using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Proveedor
    {
        public int Proveedor_Id { get; set; }
        public string Proveedor_Descripcion { get; set; }
        public string Proveedor_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Proveedor_Estatus { get; set; }
        
    }

    public class Cat_ProveedorParamId
    {
        public int Proveedor_Id { get; set; }
  
    }
}
