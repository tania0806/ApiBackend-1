using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Estatus
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int Estatus_Mail { get; set; }
        public int Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_EstatusGet
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int Estatus_Mail { get; set; }
        public int Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus { get; set; }
    }
    public class Cat_EstatusCatalogoInsert
    {
        public string Estatus_Descripcion { get; set; }
        public string Estatus_Mail { get; set; }
        public string Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus { get; set; }
    }
    public class Cat_EstatusCatalogoUpdate
    {
        public int Estatus_Id { get; set; }
        public string Estatus_Descripcion { get; set; }
        public string Estatus_Mail { get; set; }
        public string Estatus_Descripcion_Numero { get; set; }
        public string Estatus_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus { get; set; }

    }
    public class Cat_EstatusCatalogoParam
    {
        public int Estatus_Id { get; set; }

    }
}
