namespace reportesApi.Models
{
    public class SeparadoModel
    {
        public int Id { get; set; }
        public int IdSucursal { get; set; }
        public float Monto { get; set; }
        public string FolioTicket { get; set; }
        public int IdCliente { get; set; }
        public float Abonado { get; set; }
        public float Restante { get; set; }
        public int usuario {get; set;}
    }
}

