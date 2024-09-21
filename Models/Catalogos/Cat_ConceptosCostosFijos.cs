using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_ConceptosCostosFijos
    {
        public int ConceptosFijosID { get; set; }

        public string Concepto { get; set; }

        public string pUltimaModificacion { get; set; }

        public string SicID { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public int conceptoTipo { get; set; }

        public bool Estatus { get; set; }



    }

    public class Cat_ConceptosCostosFijosParam 
    
    {
        public int ConceptosFijosID { get; set; }
    }
}
