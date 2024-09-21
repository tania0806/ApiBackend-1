using System.Collections.Generic;

namespace reportesApi.Models;

public class EstadoCuentaProveedor
{
    public int Id { get; set; }
    public string Factura { get; set; }
    public string Fecha { get; set; }
    public int IdProveedor { get; set; }
    public decimal MontoEntrada { get; set; }
    public decimal MontoPagar { get; set; }
    public string NombreProveedor { get; set; }
    public string NumeroNota { get; set; }
    public decimal Iva { get; set; }
    public decimal Ieps { get; set; }
    public string FechaVencimiento { get; set; }
}

internal class GetEstadoCuentaProveedorResponse
{
    public int statusCode { get; set; }
    public string message { get; set; }
    public bool success { get; set; }
    public bodyDataEstadoCuentaProveedor response { get; set; }
}

public class bodyDataEstadoCuentaProveedor
{
    public List<EstadoCuentaProveedor> data { get; set; }
}