using System;
namespace reportesApi.Models
{
    public class MarcatelDatabaseSetting:IMarcatelDatabaseSetting
    {
        public string ConnectionString { get; set; }
    }
    public interface IMarcatelDatabaseSetting
    {
        string ConnectionString { get; set; }
    
    }

    public class UrlUpload : IUrlUpload
    {
        public string Conexion { get; set; }
    }

    public interface IUrlUpload
    {
        string Conexion { get; set; }
    }
}
