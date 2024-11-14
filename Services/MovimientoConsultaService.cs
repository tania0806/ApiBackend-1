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
 public class MovimientoConsultaService
{
        private string connectionString;
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public MovimientoConsultaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<MovimientoConsultaModel> ConsultarMovimientos(int IdAlmacen, DateTime? FechaInicio, DateTime? FechaFin)
    {
        List<MovimientoConsultaModel> movimientos = new List<MovimientoConsultaModel>();

        using (var connection = new SqlConnection(this.connection))
        
        {
            var query = @"SELECT TipoMovimiento, COUNT(*) AS TotalMovimientos
                          FROM Inv_Movimientos
                          WHERE IdAlmacen = @IdAlmacen
                          AND (@FechaInicio IS NULL OR FechaMovimiento >= @FechaInicio)
                          AND (@FechaFin IS NULL OR FechaMovimiento <= @FechaFin)
                          GROUP BY TipoMovimiento";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdAlmacen", IdAlmacen);
                command.Parameters.AddWithValue("@FechaInicio", FechaInicio.HasValue ? (object)FechaInicio.Value : DBNull.Value);
                command.Parameters.AddWithValue("@FechaFin", FechaFin.HasValue ? (object)FechaFin.Value : DBNull.Value);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movimientos.Add(new MovimientoConsultaModel
                        {
                            TipoMovimiento = reader["TipoMovimiento"].ToString(),
                            TotalMovimientos = (int)reader["TotalMovimientos"]
                        });
                    }
                }
            }
        }
        return movimientos;
    }
}


}