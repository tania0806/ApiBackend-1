using System;

public class TransferenciaModel
{
    public int IdAlmacenOrigen { get; set; }
    public int IdAlmacenDestino { get; set; }
    public int Insumo { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public int UsuarioRegistra { get; set; }
    public string TipoMovimiento { get; set; } // "Entrada" o "Salida"
}
public class MovimientoConsultaModel
{
    public string TipoMovimiento { get; set; }
    public int TotalMovimientos { get; set; }
}