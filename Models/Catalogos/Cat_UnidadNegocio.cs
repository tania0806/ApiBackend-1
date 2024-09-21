using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_UnidadNegocio
    {
        public int Unidadneg_Id { get; set; }
        public string Unidadneg_Descripcion { get; set; }
        public string Unidadneg_Sicid { get; set; }
        public int Moneda_Id { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }

    public class Cat_UnidadNegocioGet
    {
        public int Unidadneg_Id { get; set; }
        public string Unidadneg_Descripcion { get; set; }
        public string Unidadneg_Sicid { get; set; }
        public int Moneda_Id { get; set; }
        public int Metodocompensaciones_id { get; set; }

        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus_UnidadNegocio { get; set; }
    }
    public class Cat_UnidadNegocioInsert
    {
        public string Unidadneg_Descripcion { get; set; }
        public string Unidadneg_Sicid { get; set; }
        public int Moneda_Id { get; set; }
        public int Metodocompensaciones_id { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus_UnidadNegocio { get; set; }
    }
    public class Cat_UnidadNegocioUpdate
    {
        public int Unidadneg_Id { get; set; }
        public string Unidadneg_Descripcion { get; set; }
        public string Unidadneg_Sicid { get; set; }
        public int Moneda_Id { get; set; }
        public int Metodocompensaciones_id { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus_UnidadNegocio { get; set; }
    }
    public class Cat_UnidadNegocioCatalogoParam
    {
        public int Unidadneg_Id { get; set; }
    }
 }


