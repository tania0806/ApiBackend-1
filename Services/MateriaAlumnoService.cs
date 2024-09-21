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
//     public class MateriaAlumnoService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
//         private ArrayList parametros = new ArrayList();


//         public MateriaAlumnoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;

//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public List<GetMateriaAlumnoModel> GetMateriaAlumno()
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             GetMateriaAlumnoModel persona = new GetMateriaAlumnoModel();

//             List<GetMateriaAlumnoModel> lista = new List<GetMateriaAlumnoModel>();
//             try
//             {
//                 parametros = new ArrayList();
//                 DataSet ds = dac.Fill("sp_get_materiasalumnos", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {

//                   lista = ds.Tables[0].AsEnumerable()
//                     .Select(dataRow => new GetMateriaAlumnoModel {
//                         Id = int.Parse(dataRow["Id"].ToString()),
//                         Materia = dataRow["Materia"].ToString(),
//                         Matricula = dataRow["Matricula"].ToString(),
//                         Alumno = dataRow["Alumno"].ToString(),
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

//         public string InsertMateriaAlumno(InsertMateriaAlumnoModel MateriaAlumno)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;

//             parametros.Add(new SqlParameter { ParameterName = "@pIdMateria", SqlDbType = System.Data.SqlDbType.Int, Value = MateriaAlumno.IdMateria });
//             parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = MateriaAlumno.Matricula});
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_insert_materiasalumnos", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public string UpdateMateriaAlumno(UpdateMateriaAlumnoModel MateriaAlumno)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;


//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = MateriaAlumno.Id });
//             parametros.Add(new SqlParameter { ParameterName = "@pIdMateria", SqlDbType = System.Data.SqlDbType.Int, Value = MateriaAlumno.IdMateria });
//             parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = MateriaAlumno.Matricula});
//             parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.VarChar, Value = MateriaAlumno.Estatus.ToLower() == "activo" ? 1 : 0});
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

//             try
//             {
//                 DataSet ds = dac.Fill("sp_update_materiasalumnos", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }

//             return mensaje;
//         }

//         public void DeleteMateriaAlumno(int id)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_materiasalumnos", parametros);
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }