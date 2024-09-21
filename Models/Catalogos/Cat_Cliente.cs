using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Cliente
    {
        public int Cliente_Id { get; set; }
        public string Cliente_Name { get; set; }
        public string Cliente_RFC { get; set; }
        public string Cliente_Phone { get; set; }
        public string Cliente_Email { get; set; }
        public string Cliente_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_ClienteGet
    {
        public int Cliente_Id { get; set; }
        public string Cliente_Name { get; set; }
        public string Cliente_RFC { get; set; }
        public string Cliente_Phone { get; set; }
        public string Cliente_Email { get; set; }
        public string Cliente_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Cliente_Estatus { get; set; }
    }
    public class Cat_ClienteCatalogoInsert
    {
        public string Cliente_Name { get; set; }
        public string Cliente_RFC { get; set; }
        public string Cliente_Phone { get; set; }
        public string Cliente_Email { get; set; }
        public string Cliente_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Cliente_Estatus { get; set; }
    }
    public class Cat_ClienteCatalogoUpdate
    {
        public int Cliente_Id { get; set; }
        public string Cliente_Name { get; set; }
        public string Cliente_RFC { get; set; }
        public string Cliente_Phone { get; set; }
        public string Cliente_Email { get; set; }
        public string Cliente_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Cliente_Estatus { get; set; }

    }
    public class Cat_ClienteCataloParamById
    {
        public int Cliente_Id { get; set; }


    }
}

