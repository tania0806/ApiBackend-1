using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_ConceptoCapexMts
    {
        public int Conceptoscapex_id { get; set; }

        public int Concepto { get; set; }

        public int ConceptoMetros { get; set; }

        public double ConceptoCantidad { get; set; }

        public string UltimaModificacion { get; set; }

        public string Sic_Id { get; set; }

        public DateTime Fecha_Modificacion { get; set; }
        public string descripcion {get; set;}

        public bool Estatus { get; set; }


    }

    public class Cat_ConceptoCapexMtsParam
    {
        public int Conceptoscapex_id { get; set; }

       


    }
}
