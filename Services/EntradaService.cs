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
    public class EntradaService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public EntradaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetEntradaModel> GetEntrada()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetEntradaModel entrada = new GetEntradaModel();

            List<GetEntradaModel> lista = new List<GetEntradaModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_entradas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetEntradaModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        IdProveedor = int.Parse(dataRow["IdProveedor"].ToString()),
                        IdSucursal = int.Parse(dataRow["IdSucursal"].ToString()),
                        Total = decimal.Parse(dataRow["Total"].ToString()),
                        Estatus = dataRow["Estatus"].ToString(),
                        FechaEntrada = dataRow["FechaEntrada"].ToString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
        public int InsertEntrada(InsertEntradaModel entrada)
            {
                ConexionDataAccess dac = new ConexionDataAccess(connection);
                parametros = new ArrayList();
                string mensaje;
                int idInsertado;
                parametros.Add(new SqlParameter { ParameterName = "@IdProveedor", SqlDbType = System.Data.SqlDbType.Int, Value = entrada.IdProveedor });
                parametros.Add(new SqlParameter { ParameterName = "@IdSucursal", SqlDbType = System.Data.SqlDbType.Int, Value = entrada.IdSucursal });
                parametros.Add(new SqlParameter { ParameterName = "@Total", SqlDbType = System.Data.SqlDbType.Decimal, Value = entrada.Total });

                try
                {
                    DataSet ds = dac.Fill("sp_insert_entradas", parametros);
                    idInsertado = ds.Tables[0].AsEnumerable().Select(dataRow => Convert.ToInt32(dataRow["IdInsertado"])).ToList()[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                return idInsertado;  
            }


        public string UpdateEntrada(UpdateEntradaModel entrada)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = entrada.Id });
            parametros.Add(new SqlParameter { ParameterName = "@IdProveedor", SqlDbType = System.Data.SqlDbType.Int, Value = entrada.IdProveedor });
            parametros.Add(new SqlParameter { ParameterName = "@IdSucursal", SqlDbType = System.Data.SqlDbType.Int, Value = entrada.IdSucursal });
            parametros.Add(new SqlParameter { ParameterName = "@Total", SqlDbType = System.Data.SqlDbType.Decimal, Value = entrada.Total});

            try
            {
                DataSet ds = dac.Fill("sp_update_entradas", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteEntrada(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_entradas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}