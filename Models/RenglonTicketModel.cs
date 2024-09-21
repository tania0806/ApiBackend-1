public class RenglonTicketModel
    {
        public int IdSucursal { get; set; }
        public string Fecha { get; set; }
        public int Folio { get; set; }
        public int Consecutivo { get; set; }
        public string Articulo { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Unidad { get; set; }
        public float Descuento { get; set; }
        public float PrecioOriginal { get; set; }
        public float Impuestos { get; set; }
        public float Iva { get; set; }
        public float Ieps { get; set; }
        public int ConLocal { get; set; }
        public string DescripcionArticulo { get; set; }
        public int Id { get; set; }
        public float Total { get; set; }
        public int IdTicket { get; set; }
    }