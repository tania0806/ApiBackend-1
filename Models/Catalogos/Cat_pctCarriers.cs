using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_pctCarriers
    {
        public int pctCarriersID { get; set; }

        public string MesInicio { get; set; }

        public string MesFin { get; set; }

        public double pctMensual { get; set; }

        public string sic_id { get; set; }

        public string UltimaModificacion { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public bool Estatus { get; set; }

    }
    public class Cat_pctCarriersParamById
    {
        public int pctCarriersID { get; set; }

        

    }
}
