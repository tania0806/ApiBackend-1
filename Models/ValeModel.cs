using System;
namespace reportesApi.Models
{
    public class ValeModel
    {   
        public int Id { get; set; }
        public float Monto { get; set; }
        public string Motivo { get; set; }
        public int Cajero { get; set; }
        public int Supervisor { get; set; }
        public int Caja { get; set; }
    }
}
