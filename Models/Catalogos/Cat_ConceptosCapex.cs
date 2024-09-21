using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_ConceptosCapex
    {
        public int Conceptoscapex_id { get; set; }

        public string Concepto { get; set; }

        public int ConceptoInfraestrucutura { get; set; }

        public double ConceptoCosto { get; set; }

        public int ConceptoMonedaID { get; set; }

        public string pUltimaModificacion { get; set; }

        public string Sic_Id { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }



        public bool Estatus { get; set; }



    }

    public class Cat_ConceptosCapexParam 
    {
        public int Conceptoscapex_id { get; set; }


    }
}
