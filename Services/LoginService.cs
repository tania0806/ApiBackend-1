using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class LoginService
    {
        private  string connection;
        
        
        public LoginService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public UsuarioModel Login(string Correo, string Contraseña)
        {
            
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@Correo", SqlDbType = SqlDbType.VarChar, Value = Correo });
                parametros.Add(new SqlParameter { ParameterName = "@Contraseña", SqlDbType = SqlDbType.VarChar, Value = Contraseña });
                DataSet ds = dac.Fill("ValidarLogin", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.Id = int.Parse(row["Id"].ToString());
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
