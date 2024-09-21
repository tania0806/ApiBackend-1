using System.Collections.Generic;
namespace reportesApi.Models;


public class VentasInsecticidas
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
        public decimal Cantidad { get; set; }
        public int Iva { get; set; }
        public int Ieps { get; set; }
        public string Familia { get; set; }
        public decimal Costo { get; set; }
    }

    public class ResponseVI
    {
        public List<VentasInsecticidas> data { get; set; }
    }

    public class GetReporteVentasInsecticidasResponse
    {
        public int StatusCode { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public ResponseVI response { get; set; }
    }