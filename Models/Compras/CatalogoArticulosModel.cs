namespace reportesApi.Models.Compras;

public class GetCatalogoArticulos{
    public int Id { get; set;}
    public string Codigo { get; set;}
    public string Articulo { get; set;}
    public string Departamento { get; set;}
    public string Familia { get; set;}
    public decimal CostoPromedio  { get; set;}
    public int Iva {get; set;}
    public int Ieps {get; set;}
    public decimal CostoUltimaCompra { get; set;}
    public decimal PrecioVenta {get; set;}
    public decimal Existencia {get; set;}
    public string Estatus {get; set;}


}