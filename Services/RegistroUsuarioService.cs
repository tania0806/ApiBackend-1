using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;
using reportesApi.Models.Compras;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
namespace reportesApi.Services
{
    public class RegistroUsuarioService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public RegistroUsuarioService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetRegistroUsuarioModel> GetRegistroUsuario()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetRegistroUsuarioModel almacen = new GetRegistroUsuarioModel();

            List<GetRegistroUsuarioModel> lista = new List<GetRegistroUsuarioModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_usuarioregistro", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetRegistroUsuarioModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        PrimerNombre = dataRow["PrimerNombre"].ToString(),
                        Apellidos = dataRow["Apellidos"].ToString(),
                        Direccion = dataRow["Direccion"].ToString(),
                        Correo = dataRow["Correo"].ToString(),
                        Contraseña = dataRow["Contraseña"].ToString(),
                        Token = dataRow["Token"].ToString(),
                        Estatus = dataRow["Estatus"].ToString(),
                        FechaRegistro= dataRow["FechaRegistro"].ToString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string InsertRegistroUsuario(InsertRegistroUsuarioModel RegistroUsuario)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@PrimerNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = RegistroUsuario.PrimerNombre });
            parametros.Add(new SqlParameter { ParameterName = "@Apellidos", SqlDbType = System.Data.SqlDbType.VarChar, Value = RegistroUsuario.Apellidos});
            parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = RegistroUsuario.Direccion});
            parametros.Add(new SqlParameter { ParameterName = "@Correo", SqlDbType = System.Data.SqlDbType.VarChar, Value = RegistroUsuario.Correo});
            parametros.Add(new SqlParameter { ParameterName = "@Contraseña", SqlDbType = System.Data.SqlDbType.VarChar, Value = RegistroUsuario.Contraseña});

            try
            {
                DataSet ds = dac.Fill("sp_insert_registrousurio", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

      
    }
}