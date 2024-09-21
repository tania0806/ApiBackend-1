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
    public class InsumoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public InsumoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetInsumoModel> GetInsumo()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetInsumoModel insumo = new GetInsumoModel();

            List<GetInsumoModel> lista = new List<GetInsumoModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_insumos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetInsumoModel {
                        IdInsumo = int.Parse(dataRow["IdInsumo"].ToString()),
                        Usuario = dataRow["Usuario"].ToString(),
                        Insumo = dataRow["Insumo"].ToString(),
                        DescripcionInsumo = dataRow["DescripcionInsumo"].ToString(),
                        Costo = decimal.Parse(dataRow["Costo"].ToString()),
                        UnidadMedida = int.Parse(dataRow["UnidadMedida"].ToString()),
                        InsumoUp = dataRow["InsumoUp"].ToString(),
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

        public string InserInsumo(InsertInsumoModel Insumo)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.Usuario });
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionInsumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.DescripcionInsumo});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = Insumo.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@UnidadMedida", SqlDbType = System.Data.SqlDbType.Int, Value = Insumo.UnidadMedida});
            parametros.Add(new SqlParameter { ParameterName = "@InsumoUp", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.InsumoUp});

            try
            {
                DataSet ds = dac.Fill("sp_insert_insumos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string UpdateInsumo(UpdateInsumoModel Insumo)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@IdInsumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.IdInsumo });
            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.Usuario });
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@DescripcionInsumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.DescripcionInsumo});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = Insumo.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@UnidadMedida", SqlDbType = System.Data.SqlDbType.Int, Value = Insumo.UnidadMedida});
            parametros.Add(new SqlParameter { ParameterName = "@InsumoUp", SqlDbType = System.Data.SqlDbType.VarChar, Value = Insumo.InsumoUp });

            try
            {
                DataSet ds = dac.Fill("sp_update_insumos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public void DeleteInsumo(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@IdInsumo", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_insumos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}