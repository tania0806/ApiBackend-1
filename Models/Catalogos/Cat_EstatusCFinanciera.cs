using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_EstatusCFinanciera
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int Estatus_Mail { get; set; }
        public int Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool EstatusF { get; set; }

    }
    public class Cat_EstatusCFinancieraGet
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int Estatus_Mail { get; set; }
        public int Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool EstatusF { get; set; }
    }
    public class Cat_EstatusCFinancieraCatalogoInsert
    {
        public string Estatus_Descripcion { get; set; }
        public string Estatus_Mail { get; set; }
        public string Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool EstatusF { get; set; }
    }
    public class Cat_EstatusCFinancieraCatalogoUpdate
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public string Estatus_Mail { get; set; }
        public string Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool EstatusF { get; set; }

    }
    public class Cat_EstatusCFinancieraCatalogoParam
    {
        public int Estatus_Id { get; set; }

    }
}