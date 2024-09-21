using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_Periodo
    {
        public int Periodo_Id { get; set; }
        public int Periodo { get; set; }
        public string Periodo_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus { get; set; }

    }

    public class Cat_PeriodoParam
    {
     
        public string codigo { get; set; }
        public string numeroversion { get; set; }
    }

    public class Cat_PeriodoParamById
    {
        public int Periodo_Id { get; set; }

    }
}
