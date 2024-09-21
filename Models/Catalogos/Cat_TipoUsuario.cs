using System;
namespace reportesApi.Models.Catalogos
{
    public class Cat_TipoUsuario
    {
        public int TipoUsuario_Id { get; set; }
        public string TipoUsuario_Descripcion { get; set; }
        public string Tipousuario_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_TipoUsuarioCatalogo
    {
        public int TipoUsuario_Id { get; set; }
        public string TipoUsuario_Descripcion { get; set; }
        public string TipoUsuario_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool TipoUsuario_Estatus { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
    public class Cat_TipoUsuarioCatalogoParam
    {
        public int TipoUsuario_Id { get; set; }

    }
    public class Cat_TipoUsuarioCatalogoInsert
    {
        public string TipoUsuario_Descripcion { get; set; }
        public string TipoUsuario_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool TipoUsuario_Estatus { get; set; }

    }
    public class Cat_TipoUsuaroCatalogoUpdate
    {
        public int TipoUsuario_Id { get; set; }
        public string TipoUsuario_Descripcion { get; set; }
        public string TipoUsuario_Sicid { get; set; }
        public string Ultima_Modificacion { get; set; }
        public bool TipoUsuario_Estatus { get; set; }

    }

}
