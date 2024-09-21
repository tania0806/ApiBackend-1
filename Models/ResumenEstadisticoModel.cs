namespace reportesApi.Models;

    public class ReporteResumenEstadistico
    {
        public string Fecha {get; set;}
        public decimal Venta {get; set;}
        public decimal Efectivo {get; set;}
        public decimal Tarjeta {get; set;}
        public decimal Credito {get; set;}
        public decimal Devolucion {get; set;}
        public decimal Datalogic {get; set;}


    }