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
//     public class CalificacionService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
//         private ArrayList parametros = new ArrayList();


//         public CalificacionService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;

//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public List<GetCalificacionModel> GetCalificacions()
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             GetCalificacionModel persona = new GetCalificacionModel();

//             List<GetCalificacionModel> lista = new List<GetCalificacionModel>();
//             try
//             {
//                 parametros = new ArrayList();
//                 DataSet ds = dac.Fill("sp_get_calificaciones", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {

//                   lista = ds.Tables[0].AsEnumerable()
//                     .Select(dataRow => new GetCalificacionModel {
//                         Id = int.Parse(dataRow["Id"].ToString()),
//                         Matricula = dataRow["Matricula"].ToString(),
//                         NombreAlumno = dataRow["NombreAlumno"].ToString(),
//                         Materia = dataRow["Materia"].ToString(),
//                         Periodo = int.Parse(dataRow["Periodo"].ToString()),
//                         Parcial = int.Parse(dataRow["Parcial"].ToString()),
//                         Calificacion = float.Parse(dataRow["Calificacion"].ToString()),
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

//         public string InsertCalificacion(InsertCalificacionModel Calificacion)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;

//             parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Calificacion.Matricula });
//             parametros.Add(new SqlParameter { ParameterName = "@pIdMateria", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.IdMateria});
//             parametros.Add(new SqlParameter { ParameterName = "@pPeriodo", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.Periodo});
//             parametros.Add(new SqlParameter { ParameterName = "@pParcial", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.Parcial});
//             parametros.Add(new SqlParameter { ParameterName = "@pCalificacion", SqlDbType = System.Data.SqlDbType.Float, Value = Calificacion.Calificacion});
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_insert_calificaciones", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public string UpdateCalificacion(UpdateCalificacionModel Calificacion)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;


//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = Calificacion.Id });
//             parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Calificacion.Matricula });
//             parametros.Add(new SqlParameter { ParameterName = "@pIdMateria", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.IdMateria});
//             parametros.Add(new SqlParameter { ParameterName = "@pPeriodo", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.Periodo});
//             parametros.Add(new SqlParameter { ParameterName = "@pParcial", SqlDbType = System.Data.SqlDbType.Int, Value = Calificacion.Parcial});
//             parametros.Add(new SqlParameter { ParameterName = "@pCalificacion", SqlDbType = System.Data.SqlDbType.Float, Value = Calificacion.Calificacion});
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_update_Calificaciones", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }

//             return mensaje;
//         }

//         public void DeleteCalificacion(int id)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_calificaciones", parametros);
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }