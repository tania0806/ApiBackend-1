

public class DetalleModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string UM { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public float Iva { get; set; }
        public float PrecioOriginal { get; set; }
        public float PrecioFinal { get; set; }
        public float Ieps { get; set; }
        public float PrecioOriginalImpuestos { get; set; }
        public float PrecioFinalImpuestos { get; set; }
        public float TotalRenglon { get; set; }
        public float TotalRenglonImpuestos { get; set; }
        public string FolioTicket { get; set; }
        public string FolioInterno { get; set; }
        public int Folio { get; set; }
        public int ConsecutivoLocal { get; set; }

    }