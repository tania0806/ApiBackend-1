using System;

public class ArticuloModel
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string UMedida { get; set; }
        public string ImpuestoUno { get; set; }
        public string ImpuestoDos { get; set; }
        public string ImpuestoTres { get; set; }
        public int IvaSn { get; set; }
        public int IepsSn { get; set; }
        public float PrecioFinalImpuestos { get; set; }
        public float PrecioOriginalImpuestos { get; set; }
        public float PrecioOriginal { get; set; }
        public float PrecioFinal { get; set; }
        public float Iva { get; set; }
        public float Ieps { get; set; }
        public string Familia { get; set; }
        public string NombreFamilia { get; set; }
        public float UltimoPrecio { get; set; }
        public float Existencia { get; set; }
        public float Ventas { get; set; }
        public float Dias { get; set; }
        public float Cedis { get; set; }
        public float Faltante { get; set; }
        public string NombreDepartamento { get; set; }
        public string Departamento { get; set; }
        public int CostoEstandar { get; set; }
        public int TipoProducto { get; set; }
        public string nTipoProducto { get; set; }
        public string FechaUltimoPrecio { get; set; }
        public string FolioUltimaEntrada { get; set; }
        public string TipoUltimaEntrada { get; set; }
        public string ClaveSat { get; set; }
        public string FechaUltimaEntrada { get; set; }
        public int FormulaSN { get; set; }
        public string Proveedor { get; set; }
        public int IdRegistro { get; set; }

    }

