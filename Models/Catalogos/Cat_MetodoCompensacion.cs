using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_MetodoCompensacion
    {
        public int Metodocompensaciones_id { get; set; }

        public string Metodocompensaciones { get; set; }

        public string sic_id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus_MetodosCompensaciones { get; set; }

    }
    public class Cat_MetodoCompensacionGet
    {
        public int Metodocompensaciones_id { get; set; }

        public string Metodocompensaciones { get; set; }

        public string sic_id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }
        public bool Estatus_MetodosCompensaciones { get; set; }

    }
    public class Cat_MetodoCompensacionInsert
    {

        public string Metodocompensaciones { get; set; }

        public string sic_id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }

        public bool Estatus_MetodosCompensaciones { get; set; }

    }
    public class Cat_MetodoCompensacionUpdate
    {
        public int Metodocompensaciones_id { get; set; }

        public string Metodocompensaciones { get; set; }

        public string sic_id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }

        public bool Estatus_MetodosCompensaciones { get; set; }

    }
    public class Cat_MetodoCompensacionParam
    {
        public int Metodocompensaciones_id { get; set; }
    }
 }
