using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Moneda
    {
        public int Moneda_Id { get; set; }
        public string Moneda_Descripcion { get; set; }
        public string Moneda_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_MonedaCatalogo
    {
        public int Moneda_Id { get; set; }
        public string Moneda_Descripcion { get; set; }
        public string Moneda_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool Moneda_Estatus { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_MonedaCatalogoParam
    {
        public int Moneda_Id { get; set; }
      
    }
    public class Cat_MonedaCatalogoInsert
    {
        public string Moneda_Descripcion { get; set; }
        public string Moneda_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool Moneda_Estatus { get; set; }
        
    }
    public class Cat_MonedaCatalogoUpdate
    {
        public int Moneda_Id { get; set; }
        public string Moneda_Descripcion { get; set; }
        public string Moneda_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool Moneda_Estatus { get; set; }

    }

}
