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
        public IActionResult GetRenglonesMovimiento( [FromQuery] string? Fechainicial = null, 
    [FromQuery] string? Fechafinal = null)
        {
            
            var objectResponse = Helper.GetStructResponse();
    try
    {
        // Conversión de fechas a DateTime? (opcional)
        DateTime? fechaInicialParsed = string.IsNullOrWhiteSpace(Fechainicial) 
            ? (DateTime?)null 
            : DateTime.ParseExact(Fechainicial, "yyyy-MM-dd", null);
        DateTime? fechaFinalParsed = string.IsNullOrWhiteSpace(Fechafinal) 
            ? (DateTime?)null 
            : DateTime.ParseExact(Fechafinal, "yyyy-MM-dd", null);
        // Obteniendo los datos del servicio
        var data = _RenglonesMovimientoService.GetRenglonesMovimiento(fechaInicialParsed, fechaFinalParsed);
       
        // Creando el archivo Excel en memoria
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("RenglonesMovimiento");

            // Agrega encabezados
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "IdMovimiento";
            worksheet.Cells[1, 3].Value = "Insumo";
            worksheet.Cells[1, 4].Value = "DescripcionInsumo";
            worksheet.Cells[1, 5].Value = "Cantidad";
            worksheet.Cells[1, 6].Value = "Costo";
            worksheet.Cells[1, 7].Value = "Estatus";
            worksheet.Cells[1, 8].Value = "Fecha_registro";
            worksheet.Cells[1, 9].Value = "Usuario_registra";
            worksheet.Cells[1, 10].Value = "TotalCosto";

            // Aquí iteramos sobre los datos y llenamos el Excel
            int row = 2;
            foreach (var item in data)
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
                worksheet.Cells[row, 10].Value = item.TotalCosto;  
                row++;
            }

            // Configura el estilo del encabezado
            using (var range = worksheet.Cells[1, 1, 1, 10])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
            }

            // Guarda el archivo en un arreglo de bytes
            var excelBytes = package.GetAsByteArray();

            // Retorna el archivo como una descarga
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RenglonesMovimiento.xlsx");
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