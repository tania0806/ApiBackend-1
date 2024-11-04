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

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class RenglonesMovimientoController: ControllerBase
    {
   
        private readonly RenglonesMovimientoService _RenglonesMovimientoService;
        private readonly ILogger<RenglonesMovimientoController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public RenglonesMovimientoController(RenglonesMovimientoService RenglonesMovimientoService, ILogger<RenglonesMovimientoController> logger, IJwtAuthenticationService authService) {
            _RenglonesMovimientoService = RenglonesMovimientoService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertRenglonesMovimiento")]
         public IActionResult InsertRenglonesMovimiento([FromBody] InsertRenglonesMovimientoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _RenglonesMovimientoService.InsertRenglonesMovimientos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetRenglonesMovimiento")]
        public IActionResult GetRenglonesMovimiento([FromQuery] int IdMovimiento)
        {
            var objectResponse = Helper.GetStructResponse();
    
    try
    {
        // Obtiene los datos del servicio
        var resultado = _RenglonesMovimientoService.GetRenglonesMovimiento(IdMovimiento);
        
        if (resultado == null || resultado.Count == 0)
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

            // Agrega encabezados
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "IdMovimiento";
            worksheet.Cells[1, 3].Value = "Insumo";
            worksheet.Cells[1, 4].Value = "DescripcionInsumo";
            worksheet.Cells[1, 5].Value = "Cantidad";
            worksheet.Cells[1, 6].Value = "Costo";
            worksheet.Cells[1, 7].Value = "EStatus";
            worksheet.Cells[1, 8].Value = "Fecha_registro";
            worksheet.Cells[1, 9].Value = "Usuario_registra";

            // Agregar datos a las filas
            int row = 2;
            foreach (var item in resultado)
            {
                worksheet.Cells[row, 1].Value = item.Id;
                worksheet.Cells[row, 2].Value = item.IdMovimiento;
                worksheet.Cells[row, 3].Value = item.Insumo;
                worksheet.Cells[row, 4].Value = item.DescripcionInsumo;
                worksheet.Cells[row, 5].Value = item.Cantidad;
                worksheet.Cells[row, 6].Value = item.Costo;
                worksheet.Cells[row, 7].Value = item.Estatus;
                worksheet.Cells[row, 8].Value = item.Fecha_registro;
                worksheet.Cells[row, 9].Value = item.Usuario_registra;
                row++;
            }

            // Convertir el archivo Excel a un arreglo de bytes
            var excelData = package.GetAsByteArray();

            // Retorna el archivo como respuesta HTTP en formato Excel
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteMovimiento.xlsx");
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

        [HttpPut("UpdateRenglonesMovimiento")]
        public IActionResult UpdateRenglonesMovimiento([FromBody] UpdateRenglonesMovimientoModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _RenglonesMovimientoService.UpdateRenglonesMovimiento(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteRenglonesMovimiento/{id}")]
        public IActionResult DeleteRenglonesMovimiento([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _RenglonesMovimientoService.DeleteRenglonesMovimiento(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}