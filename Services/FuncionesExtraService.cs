using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class FuncionesExtraService
    {
        private  string connection;
        
        
        public FuncionesExtraService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertVale(ValeModel vale)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pMotivo", SqlDbType = SqlDbType.VarChar, Value = vale.Motivo });
                parametros.Add(new SqlParameter { ParameterName = "@pMonto", SqlDbType = SqlDbType.VarChar, Value = vale.Monto });
                parametros.Add(new SqlParameter { ParameterName = "@pCajero", SqlDbType = SqlDbType.VarChar, Value = vale.Cajero });
                dac.ExecuteNonQuery("sp_insert_vale", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int InsertRetiro(ValeModel vale)
        {

            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pSupervisor", SqlDbType = SqlDbType.VarChar, Value = vale.Supervisor });
                parametros.Add(new SqlParameter { ParameterName = "@pMonto", SqlDbType = SqlDbType.VarChar, Value = vale.Monto });
                parametros.Add(new SqlParameter { ParameterName = "@pCajero", SqlDbType = SqlDbType.VarChar, Value = vale.Cajero });
                parametros.Add(new SqlParameter { ParameterName = "@pCaja", SqlDbType = SqlDbType.VarChar, Value = vale.Caja });
                dac.ExecuteNonQuery("sp_insert_retiro", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }

        }
    }
}
