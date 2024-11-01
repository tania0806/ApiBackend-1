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
    public class ExtencionesService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public ExtencionesService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetExtencionesModel> GetExtenciones()
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            

            List<GetExtencionesModel> lista = new List<GetExtencionesModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_existencias", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetExtencionesModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Fecha = dataRow["Fecha"].ToString(),
                        Insumo = dataRow["Insumo"].ToString(),
                        Cantidad = decimal.Parse(dataRow["Cantidad"].ToString()),
                        IdAlmacen = int.Parse(dataRow["IdAlmacen"].ToString()),
                        Estatus = int.Parse(dataRow["Estatus"].ToString()),
                        Fecha_registro = dataRow["Fecha_registro"].ToString(),
                        Usuario_registra = dataRow["Usuario_registra"].ToString(),
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return lista;
        }





        public string InsertExtenciones(InsertExtencionesModel extenciones)
        {
            

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = extenciones.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = extenciones.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = System.Data.SqlDbType.Int, Value = extenciones.IdAlmacen});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = extenciones.Usuario_registra});



         try 
            {
                DataSet ds = dac.Fill("sp_insert_existencias", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            return mensaje;
        }

        public string UpdateExtenciones(UpdateExtencionesModel extenciones)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = extenciones.Id });
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = extenciones.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = extenciones.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = System.Data.SqlDbType.Int, Value = extenciones.IdAlmacen});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = extenciones.Usuario_registra});
            try
            {
                DataSet ds = dac.Fill("sp_update_existencias", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteExtenciones(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_existencias", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}