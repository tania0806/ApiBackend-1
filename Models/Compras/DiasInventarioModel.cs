using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace reportesApi.Models.Compras;

public class DiasInventarioModel
{
    public string Articulo {get; set;}
    public string Descripcion {get; set;}
    public string Familia {get; set;}
    public string Departamento {get; set;}
    public decimal VentasDo {get;set ;}
    public decimal ExisteDo {get; set;}
    public decimal VentasArb {get;set ;}
    public decimal ExisteArb {get; set;}
    public decimal VentasVill {get;set ;}
    public decimal ExisteVill {get; set;}
    public decimal VentasAll {get;set ;}
    public decimal ExisteAll {get; set;}
    public decimal VentasPet {get;set ;}
    public decimal ExistePet {get; set;}
    public decimal VentasMor {get;set ;}
    public decimal ExisteMor {get; set;}
    public decimal VentasTotales {get;set ;}
    public decimal ExisteCedis {get; set;}
    public decimal ExisteTotal {get; set;}
    public int ClaveProveedor {get; set;}

}

public class GetReporteDiasInventarioModel
{
    public string FechaInicial {get;set;}
    public string FechaFinal {get; set;}
    public int Proveedor {get; set;}

}

public class DiferenciaInventariosModel
{
    public string Codigo {get; set;}
    public string Descripcion {get;set;}
    public decimal Cantidad {get;set;}
    public decimal Existencia {get;set;}
    public decimal Diferencia {get; set;}
    public decimal UltimoCosto {get; set;}
    public decimal PrecioPublico {get; set;}
    public decimal DifCosto {get; set;}
    public decimal DifPrecio {get; set;}
    
    
    public decimal UltimoPrecio {get; set;}
}

public class DifrenciaInventariosReques
{
    public string Fecha {get; set;}
    public int Sucursal {get;set;}
}

public class FaltantesExistencia
{
    public string Codigo {get; set ;}
    public string Descripcion {get; set ;}
    public string Departamento {get; set ;}
    public decimal Cantidad {get; set ;}
    public decimal Existencia {get; set ;}
    public decimal Entcoc {get; set ;}
    public decimal Entsoc {get; set;}
    public decimal Enttra {get; set;}
    public decimal Etrans {get; set;}
    public decimal Sirota {get; set;}

}