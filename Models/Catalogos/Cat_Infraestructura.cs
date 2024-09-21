using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Models.Catalogos
{
    public class Cat_Infraestructura
    {
        public int Infraestructura_id { get; set; }

        public string Descripcion { get; set; }

        public string Sic_Id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }



    }
    public class Cat_InfraestructuraGet
    {
        public int Infraestructura_id { get; set; }

        public string Descripcion { get; set; }

        public string Sic_Id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public DateTime Fecha_Modificacion { get; set; }

        public bool Estatus_Infraestructura { get; set; }

    }
    public class Cat_InfraestructuraInsert
    {

        public string Descripcion { get; set; }

        public string Sic_Id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public bool Estatus_Infraestructura { get; set; }
       
        public DateTime Fecha_Modificacion { get; set; }


    }
    public class Cat_InfraestructuraUpdate
    {
        public int Infraestructura_id { get; set; }

        public string Descripcion { get; set; }

        public string Sic_Id { get; set; }

        public string Ultima_Modificacion { get; set; }

        public bool Estatus_Infraestructura { get; set; }

        public DateTime Fecha_Modificacion { get; set; }


    }
    public class Cat_InfraestructuraCatalogoParam
    {
        public int Infraestructura_id { get; set; }



    }
}
