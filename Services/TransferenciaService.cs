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
    public class TranferenciaService
{
    private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public TranferenciaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }
        private string connectionString;

        public bool RegistrarTransferencia(TransferenciaModel transferencia)
    {
        // Conexión a la base de datos
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Transacción para asegurar que ambas operaciones se ejecuten juntas
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Registro de salida en almacén de origen
                    var salidaCmd = new SqlCommand("sp_registrar_movimiento", connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    salidaCmd.Parameters.AddWithValue("@IdAlmacen", transferencia.IdAlmacenOrigen);
                    salidaCmd.Parameters.AddWithValue("@Insumo", transferencia.Insumo);
                    salidaCmd.Parameters.AddWithValue("@Cantidad", -transferencia.Cantidad); // Cantidad negativa para salida
                    salidaCmd.Parameters.AddWithValue("@TipoMovimiento", "Salida");
                    salidaCmd.Parameters.AddWithValue("@FechaMovimiento", transferencia.FechaMovimiento);
                    salidaCmd.Parameters.AddWithValue("@Usuario_registra", transferencia.UsuarioRegistra);
                    salidaCmd.ExecuteNonQuery();

                    // Registro de entrada en almacén de destino
                    var entradaCmd = new SqlCommand("sp_registrar_movimiento", connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    entradaCmd.Parameters.AddWithValue("@IdAlmacen", transferencia.IdAlmacenDestino);
                    entradaCmd.Parameters.AddWithValue("@Insumo", transferencia.Insumo);
                    entradaCmd.Parameters.AddWithValue("@Cantidad", transferencia.Cantidad); // Cantidad positiva para entrada
                    entradaCmd.Parameters.AddWithValue("@TipoMovimiento", "Entrada");
                    entradaCmd.Parameters.AddWithValue("@FechaMovimiento", transferencia.FechaMovimiento);
                    entradaCmd.Parameters.AddWithValue("@Usuario_registra", transferencia.UsuarioRegistra);
                    entradaCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}

}

