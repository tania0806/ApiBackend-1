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
    public class AlumnoService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public AlumnoService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetAlumnoModel> GetAlumnos()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetAlumnoModel persona = new GetAlumnoModel();

            List<GetAlumnoModel> lista = new List<GetAlumnoModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_alumnos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetAlumnoModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Matricula = dataRow["Matricula"].ToString(),
                        Nombre = dataRow["Nombre"].ToString(),
                        ApPaterno = dataRow["ApellidoPaterno"].ToString(),
                        ApMaterno = dataRow["ApellidoMaterno"].ToString(),
                        Direccion = dataRow["Direccion"].ToString(),
                        Estatus = dataRow["Estatus"].ToString(),
                        UsuarioRegistra = dataRow["UsuarioRegistra"].ToString(),
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

        public string InsertAlumno(InsertAlumnoModel Alumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.ApPaterno});
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.ApMaterno});
            parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Direccion});
            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Matricula});
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

            try
            {
                DataSet ds = dac.Fill("sp_insert_alumno", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string UpdateAlumno(UpdateAlumnoModel Alumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.ApPaterno});
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.ApMaterno});
            parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Direccion});
            parametros.Add(new SqlParameter { ParameterName = "@pMatricula", SqlDbType = System.Data.SqlDbType.VarChar, Value = Alumno.Matricula});
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

            try
            {
                DataSet ds = dac.Fill("sp_update_alumnos", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public void DeleteAlumno(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


            try
            {
                dac.ExecuteNonQuery("sp_delete_alumnos", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}