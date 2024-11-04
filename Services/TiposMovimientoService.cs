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
    public class TiposMovimientoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public TiposMovimientoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetTiposMovimientoModel> GetTiposMovimiento()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetTiposMovimientoModel tiposmovimiento = new GetTiposMovimientoModel();

            List<GetTiposMovimientoModel> lista = new List<GetTiposMovimientoModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_tiposmovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetTiposMovimientoModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Nombre = dataRow["Nombre"].ToString(),
                        EntradaSalida = int.Parse(dataRow["EntradaSalida"].ToString()),
                        TipoMovimiento = int.Parse(dataRow["EntradaSalida"].ToString()) == 1 ? "Entrada" : 
                                     int.Parse(dataRow["EntradaSalida"].ToString()) == 2 ? "Salida" : "Desconocido",
                        Estatus = int.Parse(dataRow["Estatus"].ToString()),
                        Fecha_registro = dataRow["Fecha_registro"].ToString(),
                        Usuario_registra = dataRow["Usuario_registra"].ToString(),

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string InsertTiposMovimeinto(InsertTiposMovimientosModel tm)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = tm.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@EntradaSalida", SqlDbType = System.Data.SqlDbType.Int, Value = tm.EntradaSalida});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = tm.Usuario_registra});

            try 
            {
                DataSet ds = dac.Fill("sp_insert_tiposmovimiento", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return mensaje;
        }

        public string UpdateTiposMovimiento(UpdateTiposMovimientosModel tm)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = tm.Id });
            parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = tm.Nombre});
            parametros.Add(new SqlParameter { ParameterName = "@EntradaSalida", SqlDbType = System.Data.SqlDbType.Int, Value = tm.EntradaSalida});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = tm.UsuarioRegistra});

            try
            {
                DataSet ds = dac.Fill("sp_update_tiposmovimiento", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteTiposMovimiento(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_tiposmovimiento", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}