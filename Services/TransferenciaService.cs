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
    public class TransferenciaService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public TransferenciaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        // public List<GetTransferenciaModel> GetTransferencia()
        // {

        //     ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     parametros = new ArrayList();
        
      
            public List<GetTransferenciaModel> GetTransferencias(int? almacen = null, DateTime? fechaInicio = null, DateTime? fechaFinal = null, int? tipoMovimiento = null)
                {
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    List<GetTransferenciaModel> lista = new List<GetTransferenciaModel>();
                    parametros = new ArrayList
                    {
                        new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = SqlDbType.Int, Value = (object)almacen ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = SqlDbType.DateTime, Value = (object)fechaInicio ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@FechaFinal", SqlDbType = SqlDbType.DateTime, Value = (object)fechaFinal ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@TipoMovimiento", SqlDbType = SqlDbType.Int, Value = (object)tipoMovimiento ?? DBNull.Value }
                    };

                    try
                    {
                        DataSet ds = dac.Fill("sp_get_registrarmovimientos", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lista = ds.Tables[0].AsEnumerable().Select(dataRow => new GetTransferenciaModel
                            {
                                Id = int.Parse(dataRow["Id"].ToString()),
                                IdAlmacenOrigen = int.Parse(dataRow["IdAlmacenOrigen"].ToString()),
                                NombreAlmacenOrigen = dataRow["NombreAlmacenOrigen"].ToString(),
                                IdAlmacenDestino = int.Parse(dataRow["IdAlmacenDestino"].ToString()),
                                 NombreAlmacenDestino = dataRow["NombreAlmacenDestino"].ToString(),
                                Insumo = int.Parse(dataRow["Insumo"].ToString()),
                                DescripcionInsumo = dataRow["DescripcionInsumo"].ToString(),
                                Cantidad = decimal.Parse(dataRow["Cantidad"].ToString()),
                                FechaMovimiento = dataRow["FechaMovimiento"].ToString(),
                                EntradaSalida = int.Parse(dataRow["EntradaSalida"].ToString()),
                                TipoMovimiento = dataRow["TipoMovimiento"].ToString(),
                                Estatus = int.Parse(dataRow["Estatus"].ToString()),
                                Fecha_registra = dataRow["Fecha_registra"].ToString(),
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
                 public List<GetTransferenciaModel> GetT(int? almacen = null, DateTime? fechaInicio = null, DateTime? fechaFinal = null, int? tipoMovimiento = null)
                {
                    ConexionDataAccess dac = new ConexionDataAccess(connection);
                    List<GetTransferenciaModel> lista = new List<GetTransferenciaModel>();
                    parametros = new ArrayList
                    {
                        new SqlParameter { ParameterName = "@IdAlmacen", SqlDbType = SqlDbType.Int, Value = (object)almacen ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@FechaInicio", SqlDbType = SqlDbType.DateTime, Value = (object)fechaInicio ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@FechaFinal", SqlDbType = SqlDbType.DateTime, Value = (object)fechaFinal ?? DBNull.Value },
                        new SqlParameter { ParameterName = "@TipoMovimiento", SqlDbType = SqlDbType.Int, Value = (object)tipoMovimiento ?? DBNull.Value }
                    };

                    try
                    {
                        DataSet ds = dac.Fill("sp_get_rgmovimientos", parametros);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lista = ds.Tables[0].AsEnumerable().Select(dataRow => new GetTransferenciaModel
                            {
                                Id = int.Parse(dataRow["Id"].ToString()),
                                IdAlmacenOrigen = int.Parse(dataRow["IdAlmacenOrigen"].ToString()),
                                NombreAlmacenOrigen = dataRow["NombreAlmacenOrigen"].ToString(),
                                IdAlmacenDestino = int.Parse(dataRow["IdAlmacenDestino"].ToString()),
                                NombreAlmacenDestino = dataRow["NombreAlmacenDestino"].ToString(),
                                Insumo = int.Parse(dataRow["Insumo"].ToString()),
                                DescripcionInsumo = dataRow["DescripcionInsumo"].ToString(),
                                Cantidad = decimal.Parse(dataRow["Cantidad"].ToString()),
                                FechaMovimiento = dataRow["FechaMovimiento"].ToString(),
                                EntradaSalida = int.Parse(dataRow["EntradaSalida"].ToString()),
                                TipoMovimiento = dataRow["TipoMovimiento"].ToString(),
                                Estatus = int.Parse(dataRow["Estatus"].ToString()),
                                Fecha_registra = dataRow["Fecha_registra"].ToString(),
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

        public string InsertTransferencia(InsertTransferenciaModel rm)
        {
            
            
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacenOrigen", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdAlmacenOrigen});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacenDestino", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdAlmacenDestino});
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = rm.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@EntradaSalida", SqlDbType = System.Data.SqlDbType.Int, Value = rm.EntradaSalida});
            
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Usuario_registra});

         try 
            {
                DataSet ds = dac.Fill("sp_insert_registrarmovimiento", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
                
            }
            catch (Exception ex)
            {
            
                throw ex;
            }
             return mensaje;
           
        }

        public string UpdateTransferenciaModel(UpdateTransferenciaModel rm)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Id });
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacenOrigen", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdAlmacenOrigen});
            parametros.Add(new SqlParameter { ParameterName = "@IdAlmacenDestino", SqlDbType = System.Data.SqlDbType.Int, Value = rm.IdAlmacenDestino});
            parametros.Add(new SqlParameter { ParameterName = "@Insumo", SqlDbType = System.Data.SqlDbType.VarChar, Value = rm.Insumo});
            parametros.Add(new SqlParameter { ParameterName = "@Cantidad", SqlDbType = System.Data.SqlDbType.Decimal, Value = rm.Cantidad});
            parametros.Add(new SqlParameter { ParameterName = "@EntradaSalida", SqlDbType = System.Data.SqlDbType.Int, Value = rm.EntradaSalida});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario_registra", SqlDbType = System.Data.SqlDbType.Int, Value = rm.Usuario_registra});


            try
            {
                DataSet ds = dac.Fill("sp_update_regsitrarmovimientos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

      public void DeleteTransferencias(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id });


            try
            {
                dac.ExecuteNonQuery("sp_delete_registrar", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}