using System;

public class GetTransferenciaModel
{
   public int Id { get; set; }
    public string FechaMovimiento { get; set; }
    public int EntradaSalida{ get; set; }
    public string TipoMovimiento { get; set; }
    public int IdAlmacenOrigen { get; set; }
    public string NombreAlmacenOrigen { get; set; }
    public int IdAlmacenDestino { get; set; }
    public string NombreAlmacenDestino { get; set; }
    public int Insumo { get; set; }
    public string DescripcionInsumo {get; set;}
    public decimal Cantidad { get; set; }
    public string Fecha_registra {get; set;}
    public string Usuario_registra {get; set;}
    public int Estatus {get; set;}
}
public class InsertTransferenciaModel
{
   
    
    public int EntradaSalida{ get; set; }
    public int IdAlmacenOrigen { get; set; }
    public int IdAlmacenDestino { get; set; }
    public int Insumo { get; set; }
    public decimal Cantidad { get; set; }
    public string Usuario_registra {get; set;}
   
}
public class UpdateTransferenciaModel
{
   public int Id { get; set; }
    
    public int EntradaSalida{ get; set; }
    public int IdAlmacenOrigen { get; set; }
    public int IdAlmacenDestino { get; set; }
    public int Insumo { get; set; }
    public decimal Cantidad { get; set; }

    public string Usuario_registra {get; set;}
}