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
//     public class PersonaService
//     {
//         private  string connection;
//         private readonly IWebHostEnvironment _webHostEnvironment;
//         private ArrayList parametros = new ArrayList();


//         public PersonaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
//         {
//              connection = settings.ConnectionString;

//              _webHostEnvironment = webHostEnvironment;
             
//         }

//         public List<GetPersonaModel> GetPersonas()
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             GetPersonaModel persona = new GetPersonaModel();

//             List<GetPersonaModel> lista = new List<GetPersonaModel>();
//             try
//             {
//                 parametros = new ArrayList();
//                 DataSet ds = dac.Fill("sp_get_personas", parametros);
//                 if (ds.Tables[0].Rows.Count > 0)
//                 {

//                   lista = ds.Tables[0].AsEnumerable()
//                     .Select(dataRow => new GetPersonaModel {
//                         Id = int.Parse(dataRow["Id"].ToString()),
//                         Nombre = dataRow["Nombre"].ToString(),
//                         ApPaterno = dataRow["ApPaterno"].ToString(),
//                         ApMaterno = dataRow["ApMaterno"].ToString(),
//                         Direccion = dataRow["Direccion"].ToString(),
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

//         public string InsertPersona(InsertPersonaModel persona)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje; 
//             parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
//             parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApPaterno });
//             parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApMaterno });
//             parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Direccion });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

//             try
//             {
//                 DataSet ds = dac.Fill("sp_insert_personas", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public string UpdatePersona(UpdatePersonaModel persona)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             string mensaje; 

//             parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Id });
//             parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
//             parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApPaterno });
//             parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApMaterno });
//             parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Direccion });
//             parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

//             try
//             {
//                 DataSet ds = dac.Fill("sp_update_persona", parametros);
//                 mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//             return mensaje;
//         }

//         public void DeletePersona(int id)
//         {
//             ConexionDataAccess dac = new ConexionDataAccess(connection);
//             parametros = new ArrayList();
//             parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = id });

//             try
//             {
//                 dac.ExecuteNonQuery("sp_delete_persona", parametros);
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }