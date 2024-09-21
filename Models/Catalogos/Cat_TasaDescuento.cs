using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_TasaDescuento
    {
        public int TasaDescuento_Id        { get; set; }
        public double Tasa_Descuento        { get; set; }
        public string TasaDescuento_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_TasaDescuentoCatalogo
    {


     

        public int TasaDescuento_Id { get; set; }
        public double Tasa_Descuento { get; set; }
        public string TasaDescuento_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_TasaDescuentoCatalogoParam
    {
        public int TasaDescuento_Id { get; set; }

    }
    public class Cat_TasaDescuentoCatalogoInsert
    {

        public double Tasa_Descuento { get; set; }
        public string TasaDescuento_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
      

    }
    public class Cat_TasaDescuentoCatalogoUpdate
    {
        public int TasaDescuento_Id { get; set; }
        public double Tasa_Descuento { get; set; }
        public string TasaDescuento_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
       

    }

}