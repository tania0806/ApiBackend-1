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
//     public class MateriaService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
//         private ArrayList parametros = new ArrayList();


//         public MateriaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;

//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public List<GetMateriaModel> GetMaterias()
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             GetMateriaModel persona = new GetMateriaModel();

//             List<GetMateriaModel> lista = new List<GetMateriaModel>();
//             try
//             {
//                 parametros = new ArrayList();
//                 DataSet ds = dac.Fill("sp_get_materias", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {

//                   lista = ds.Tables[0].AsEnumerable()
//                     .Select(dataRow => new GetMateriaModel {
//                         Id = int.Parse(dataRow["Id"].ToString()),
//                         NombreMateria = dataRow["NombreMateria"].ToString(),
//                         ClaveMateria = dataRow["ClaveMateria"].ToString(),
//                         ClaveCarrera = dataRow["ClaveCarrera"].ToString(),
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

//         public string InsertMateria(InsertMateriaModel Materia)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;

//             parametros.Add(new SqlParameter { ParameterName = "@pNombreMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.NombreMateria });
//             parametros.Add(new SqlParameter { ParameterName = "@pClaveMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.ClaveMateria});
//             parametros.Add(new SqlParameter { ParameterName = "@pIdCarrera", SqlDbType = System.Data.SqlDbType.Int, Value = Materia.IdCarrera });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_insert_materia", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public string UpdateMateria(UpdateMateriaModel Materia)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje;


//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.Id });
//             parametros.Add(new SqlParameter { ParameterName = "@pNombreMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.NombreMateria });
//             parametros.Add(new SqlParameter { ParameterName = "@pClaveMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.ClaveMateria });
//             parametros.Add(new SqlParameter { ParameterName = "@pIdCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = Materia.IdCarrera });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

//             try
//             {
//                 DataSet ds = dac.Fill("sp_update_materias", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }

//             return mensaje;
//         }

//         public void DeleteMateria(int id)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_materias", parametros);
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }