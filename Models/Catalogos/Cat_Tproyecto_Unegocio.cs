using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Tproyecto_Unegocio
    {
        public int Tproyecto_Unegocio_Id { get; set; }

        public int TipoProyecto_Id { get; set; }
        public string  TipoProyecto { get; set; }
        public int UnidadNeg_Id { get; set; }
        public string Tproyecto_Unegocio_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_TProyecto_Unegocio_Param {
        public int UnidadNeg_Id { get; set; }
        public int Idusr { get; set; }

    }
}
