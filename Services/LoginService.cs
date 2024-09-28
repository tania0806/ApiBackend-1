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

        public UsuarioModel Login(string correo, string contraseña)
        {
            
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@Correo", SqlDbType = SqlDbType.VarChar, Value = correo });
                parametros.Add(new SqlParameter { ParameterName = "@Contraseña", SqlDbType = SqlDbType.VarChar, Value = contraseña });
                DataSet ds = dac.Fill("sp_login_pv", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        usuario.Correo = row["Correo"].ToString();
                        usuario.Contraseña = row["Contraseña"].ToString();                    
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
