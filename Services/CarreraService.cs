// using System;
// using System.Collections;
// using System.Data;
// using System.Data.SqlClient;
// using reportesApi.DataContext;
// using reportesApi.Models;
// using System.Collections.Generic;
// using reportesApi.Models.Compras;
// using OfficeOpenXml;
// using Microsoft.AspNetCore.Hosting;
// using System.IO;
// using Microsoft.AspNetCore.Mvc;
// using System.Drawing.Printing;
// using System.Linq;
// using System.Text;
// namespace reportesApi.Services
// {
//     public class CarreraService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
//         private ArrayList parametros = new ArrayList();


//         public CarreraService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;

//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public List<GetCarreraModel> GetCarreras()
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             GetCarreraModel persona = new GetCarreraModel();

//             List<GetCarreraModel> lista = new List<GetCarreraModel>();
//             try
//             {
//                 parametros = new ArrayList();
//                 DataSet ds = dac.Fill("sp_get_carreras", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {

//                   lista = ds.Tables[0].AsEnumerable()
//                     .Select(dataRow => new GetCarreraModel {
//                         Id = int.Parse(dataRow["Id"].ToString()),
//                         NombreCarrera = dataRow["NombreCarrera"].ToString(),
//                         Abreviatura = dataRow["Abreviatura"].ToString(),
//                         Estatus = dataRow["Estatus"].ToString(),
//                         UsuarioRegistra = dataRow["UsuarioRegistra"].ToString(),
//                         FechaRegistro= dataRow["FechaRegistro"].ToString()
//                     }).ToList();
//                 }
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return lista;
//         }

//         public string InsertCarrera(InsertCarreraModel carrera)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;

//             parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.NombreCarrera });
//             parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Abreviatura });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_insert_carrera", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public string UpdateCarrera(UpdateCarreraModel carrera)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;


//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Id });
//             parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.NombreCarrera });
//             parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Abreviatura });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

//             try
//             {
//                 DataSet ds = dac.Fill("sp_update_carreras", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }

//             return mensaje;
//         }

//         public void DeleteCarrera(int id)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_carreras", parametros);
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }