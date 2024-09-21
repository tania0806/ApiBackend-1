namespace reportesApi.Models
{
    public class DescuentosUsuarioModel
    { 
        public int Id { get; set; }
        public int Descuento { get; set; }
        public int IdUsuario { get; set; }
        public int UserRegsitra { get; set; }
        public string Nombre { get; set; }
    }
}

