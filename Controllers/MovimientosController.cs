using System;
using Microsoft.AspNetCore.Mvc;
using reportesApi.Services;
using reportesApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using reportesApi.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using reportesApi.Helpers;
using Newtonsoft.Json;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.AspNetCore.Hosting;
using reportesApi.Models.Compras;
using System.Linq;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class MovimientosController: ControllerBase
    {
   
        private readonly MovimientosService _MovimientosService;
        private readonly ILogger<MovimientosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public MovimientosController(MovimientosService MovimientosService, ILogger<MovimientosController> logger, IJwtAuthenticationService authService) {
            _MovimientosService = MovimientosService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertMovimientos")]
         public IActionResult InsertMovimientos([FromBody] InsertMovimientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MovimientosService.InsertMovimientos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetMovimientos")]
        public IActionResult GetMovimientos([FromQuery] int IdTipoMovimiento, DateTime? startDate = null, DateTime? endDate = null, int? IdAlmacen = null)
        {
            var objectResponse = Helper.GetStructResponse();

    try
    {
        // Obtiene los datos del servicio
        var resultado = _MovimientosService.GetMovimientos(IdTipoMovimiento);

        // Aplicar filtros de fecha y almacén si se han proporcionado
        if (startDate.HasValue && endDate.HasValue)
            resultado = resultado.Where(r => r.Fecha >= startDate && r.Fecha <= endDate).ToList();

         if (IdAlmacen.HasValue)
            resultado = resultado.Where(r => r.IdAlmacen.Equals(IdAlmacen.Value)).ToList();

        // Verificar si hay datos después de filtrar
        if (resultado == null || resultado.Count == 0 )
        {
            objectResponse.StatusCode = (int)HttpStatusCode.NotFound;
            objectResponse.success = false;
            objectResponse.message = "No se encontraron datos para el movimiento solicitado";
            return new JsonResult(objectResponse);
        }

        // Crear el archivo Excel
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Reporte");

            // Agregar encabezados
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "IdTipoMovimiento";
            worksheet.Cells[1, 3].Value = "TipoMovimiento";
            worksheet.Cells[1, 4].Value = "IdAlmacen";
            worksheet.Cells[1, 5].Value = "Fecha";
            worksheet.Cells[1, 6].Value = "Estatus";
            worksheet.Cells[1, 7].Value = "Fecha_registro";
            worksheet.Cells[1, 8].Value = "IdUsuario";

            // Agregar datos a las filas
            int row = 2;
            foreach (var item in resultado)
            {
                worksheet.Cells[row, 1].Value = item.Id;
                worksheet.Cells[row, 2].Value = item.IdTiposMovimeinto;
                worksheet.Cells[row, 3].Value = item.Nombre;
                worksheet.Cells[row, 4].Value = item.IdAlmacen;
                worksheet.Cells[row, 5].Value = item.Fecha.ToString("yyyy-MM-dd");
                worksheet.Cells[row, 6].Value = item.Estatus;
                worksheet.Cells[row, 7].Value = item.Fecha_registro;
                worksheet.Cells[row, 8].Value = item.IdUsuario;
                row++;
            }

            // Convertir el archivo Excel a un arreglo de bytes
            var excelData = package.GetAsByteArray();

            // Retorna el archivo como respuesta HTTP en formato Excel
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteMovimientos.xlsx");
        }
    }
    catch (Exception ex)
    {
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        objectResponse.success = false;
        objectResponse.message = ex.Message;
        return new JsonResult(objectResponse);
    }
        }

        [HttpPut("UpdateMovimientos")]
        public IActionResult UpdateMovimientos([FromBody] UpdateMovimientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MovimientosService.UpdateMovimientos(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteMovimientos/{id}")]
        public IActionResult DeleteMovimientos([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _MovimientosService.DeleteMovimientos(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}