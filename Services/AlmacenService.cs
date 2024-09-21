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
    public class AlmacenService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public AlmacenService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetAlmacenModel> GetAlmacen()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetAlmacenModel almacen = new GetAlmacenModel();

            List<GetAlmacenModel> lista = new List<GetAlmacenModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_almacenes", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetAlmacenModel {
                        IdAlmacen = int.Parse(dataRow["IdAlmacen"].ToString()),
                        Usuario = dataRow["Usuario"].ToString(),
                        Nombre = dataRow["Nombre"].ToString(),
                        Direccion = dataRow["Direccion"].ToString(),
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

        public string InsertAlmacen(InsertAlmacenModel Almacen)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Usuario });
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Direccion});

            try
            {
                DataSet ds = dac.Fill("sp_insert_almacenes", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string UpdateAlmacen(UpdateAlmacenModel Almacen)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.IdAlmacen });
            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Usuario });
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = Almacen.Direccion});

            try
            {
                DataSet ds = dac.Fill("sp_update_almacenes", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteAlmacen(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_almacenes", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}