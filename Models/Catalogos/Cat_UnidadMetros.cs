using System;

namespace reportesApi.Models.Catalogos
{
    public class Cat_UnidadMetros
    {
        public int UnidadMetros_id { get; set; }
        public int UnidadMetros_Descripcion{ get; set; }
        public string UnidadMetros_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_UnidadMetrosCatalogo
    {
      
      
    
  
        public int UnidadMetros_id { get; set; }
        public int UnidadMetros_Descripcion { get; set; }
        public string UnidadMetros_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool UnidadMetros_Estatus { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_UnidadMetrosCatalogoParam
    {
        public int UnidadMetros_Id { get; set; }

    }
    public class Cat_UnidadMetrosCatalogoInsert
    {
      
        public int UnidadMetros_Descripcion { get; set; }
        public string UnidadMetros_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool UnidadMetros_Estatus { get; set; }

    }
    public class Cat_UnidadMetrosCatalogoUpdate
    {
        public int UnidadMetros_Id { get; set; }
        public int UnidadMetros_Descripcion { get; set; }
        public string UnidadMetros_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool UnidadMetros_Estatus { get; set; }

    }

}
