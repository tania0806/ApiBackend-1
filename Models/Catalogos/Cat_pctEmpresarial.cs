using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_pctEmpresarial
    {
        public int pctEmpresarialId { get; set; }

        public double MensualRenta { get; set; }

        public double MensualConsumo { get; set; }

        public double PeriodoRenta { get; set; }

        public double PeriodoConsumo { get; set; }

        public int PeriodoEmpresarial { get; set; }

        public string sic_id { get; set; }

        public string pUltimaModificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }

        public int TipoProyectoId { get; set; }

        public bool Estatus { get; set; }

    }
    public class Cat_pctEmpresarialParamById
    {
        public int pctEmpresarialId { get; set; }

        

    }

}
