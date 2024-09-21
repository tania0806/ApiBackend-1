

using System;
namespace reportesApi.Models.Catalogos
{
    public class CatTipoProyectoCatalogo
    {
        public int TipoProyecto_Id { get; set; }
        public string TipoProyecto { get; set; }
        public string TipoProyecto_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool TipoProyecto_Estatus { get; set; }
    }
    public class Cat_TipoProyectoCatalogoParam
    {
        public int TipoProyecto_Id { get; set; }

    }
    public class Cat_TipoProyectoCatalogoInsert
    {

        public string TipoProyecto { get; set; }
        public string TipoProyecto_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool TipoProyecto_Estatus { get; set; }

    }
    public class Cat_TipoProyectoCatalogoUpdate
    {
        public int TipoProyecto_Id { get; set; }
        public string TipoProyecto { get; set; }
        public string TipoProyecto_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool TipoProyecto_Estatus { get; set; }

    }

}


