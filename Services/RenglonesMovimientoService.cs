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
    public class RenglonesMovimientoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public RenglonesMovimientoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetRenglonesMovimientoModel> GetRenglonesMovimiento(DateTime? Fechainicial = null, DateTime? Fechafinal = null)
        {

            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
           
                // Agregar parámetros de fecha si no son nulos
            if (Fechainicial.HasValue)
                parametros.Add(new SqlParameter("@Fechainicial", Fechainicial.Value));
            else
                parametros.Add(new SqlParameter("@Fechainicial", DBNull.Value));

            if (Fechafinal.HasValue)
                parametros.Add(new SqlParameter("@Fechafinal", Fechafinal.Value));
            else
                parametros.Add(new SqlParameter("@Fechafinal", DBNull.Value));
            

            List<GetRenglonesMovimientoModel> lista = new List<GetRenglonesMovimientoModel>();
            try
            {
                DataSet ds = dac.Fill("sp_get_renglonesmovimiento", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetRenglonesMovimientoModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        IdMovimiento = int.Parse(dataRow["IdMovimiento"].ToString()),
                        Insumo = dataRow["Insumo"].ToString(),
                        DescripcionInsumo = dataRow["DescripcionInsumo"].ToString(),
                        Cantidad = decimal.Parse(dataRow["Cantidad"].ToString()),
                        Costo = decimal.Parse(dataRow["Costo"].ToString()),
                        TotalCosto = dataRow["TotalCosto"].ToString(),
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

        public string InsertRenglonesMovimientos(InsertRenglonesMovimientoModel rm)
        {
            
            int IdMovimiento;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;
            parametros.Add(new SqlParameter { ParameterName = "@IdMovimiento", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdMovimiento});
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = rm.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Usuario_registra});



         try 
            {
                DataSet ds = dac.Fill("sp_insert_renglonesmovimiento", parametros);
                IdMovimiento = ds.Tables[0].AsEnumerable().Select(dataRow=>int.Parse(dataRow["IdMovimiento"].ToString())).ToList()[0];
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
                throw ex;
            }
            return  IdMovimiento.ToString();
        }

        public string UpdateRenglonesMovimiento(UpdateRenglonesMovimientoModel rm)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Id });
            parametros.Add(new SqlParameter { ParameterName = "@IdMovimiento", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdMovimiento});
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = rm.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Usuario_registra});

            try
            {
                DataSet ds = dac.Fill("sp_update_renglonesmovimiento", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteRenglonesMovimiento(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_renglonesmovimiento", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}