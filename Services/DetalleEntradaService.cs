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
    public class DetalleEntradaService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public DetalleEntradaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetDetalleEntadaModel> GetDetalleEntrada(int id)
        {
            // Preparar la conexión
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@IdEntrada", SqlDbType = SqlDbType.Int, Value = id });

            // Lista para almacenar los detalles obtenidos
            List<GetDetalleEntadaModel> detalles = new List<GetDetalleEntadaModel>();

            try
            {
                // Llenar el DataSet con el resultado del procedimiento almacenado
                DataSet ds = dac.Fill("sp_get_detalleentrada", parametros);
                
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)  // Asegurarse que hay filas en la tabla
                {
                    detalles = ds.Tables[0].AsEnumerable().Select(dataRow => new GetDetalleEntadaModel
                    {
                                Id = int.Parse(dataRow["Id"].ToString()),
                                IdEntrada = int.Parse(dataRow["IdEntrada"].ToString()),
                                Insumo = dataRow["Insumo"].ToString(),
                                Cantidad = int.Parse(dataRow["Cantidad"].ToString()),
                                Costo = decimal.Parse(dataRow["Costo"].ToString()),
                                Estatus = int.Parse(dataRow["Estatus"].ToString()),
                                UsuarioRegistra = dataRow["UsuarioRegistra"].ToString(),


                    }).ToList();
                }
                else
                {
                    // Aquí puedes manejar la situación cuando no hay resultados
                    throw new Exception("No se encontraron detalles para el IdEntrada proporcionado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles: " + ex.Message);
            }

            return detalles;  // Devolver la lista de detalles obtenidos
        }



        public string InsertDetalleEntrada(InsertDetalleEntradaModel detalleentrada)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;
            parametros.Add(new SqlParameter { ParameterName = "@IdEntrada", SqlDbType = System.Data.SqlDbType.Int, Value = detalleentrada.IdEntrada });
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = detalleentrada.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = detalleentrada.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = detalleentrada.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = detalleentrada.UsuarioRegistra });



            try
            {
                DataSet ds = dac.Fill("sp_insert_detalleentrada", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string UpdateDetalleEntrada(UpdateDetalleEntradaModel detalleentrada)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = detalleentrada.Id });
            parametros.Add(new SqlParameter { ParameterName = "@IdEntrada", SqlDbType = System.Data.SqlDbType.Int, Value = detalleentrada.IdEntrada });
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = detalleentrada.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = detalleentrada.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@SinCargo", SqlDbType = System.Data.SqlDbType.Decimal, Value = detalleentrada.SinCargo});
            parametros.Add(new SqlParameter { ParameterName = "@Costo", SqlDbType = System.Data.SqlDbType.Decimal, Value = detalleentrada.Costo});
            parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = detalleentrada.UsuarioRegistra });

            try
            {
                DataSet ds = dac.Fill("sp_update_detalleentrada", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteDetalleEntrada(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_detalleentrada", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}