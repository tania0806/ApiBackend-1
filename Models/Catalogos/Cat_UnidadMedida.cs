using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_UnidadMedidaSelect
    {
        public int UnidadMedida_Id { get; set; }
        public string UnidadMedida_Descripcion { get; set; }
        public string Unidad_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
        public class Cat_UnidadMedidaGet
    {
        public int UnidadMedida_Id { get; set; }
        public string UnidadMedida_Descripcion { get; set; }
        public string Unidad_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Medida_Estatus {get; set; }
    }
    public class Cat_UnidadMedidasInsert
    {
        public string UnidadMedida_Descripcion { get; set; }
        public string Unidad_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Medida_Estatus { get; set; }
    }
    public class Cat_UnidadMedidasUpdate
    {
        public int unidadmedida_id { get; set; }
        public string UnidadMedida_Descripcion { get; set; }
        public string Unidad_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Medida_Estatus { get; set; }
    }
    public class Cat_UnidadMEdidaCatalogoParam
    {
        public int unidadmedida_id { get; set; }

    }
}
