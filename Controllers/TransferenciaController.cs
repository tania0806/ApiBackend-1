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
    public class TransferenciaController: ControllerBase
    {
   
        private readonly TransferenciaService _TransferenciaService;
        private readonly ILogger<TransferenciaController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public TransferenciaController(TransferenciaService TransferenciaService, ILogger<TransferenciaController> logger, IJwtAuthenticationService authService) {
            _TransferenciaService = TransferenciaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertTransferencia")]
        public IActionResult InsertTransfarencia([FromBody] InsertTransferenciaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _TransferenciaService.InsertTransferencia(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetTransferencia")]
            public IActionResult GetTransferencia(
                [FromQuery] string? FechaInicio = null, 
                [FromQuery] string? FechaFinal = null, 
                [FromQuery] int? IdAlmacen = null,
                [FromQuery] int? TipoMovimiento = null)
            {
                var objectResponse = Helper.GetStructResponse();

                try
                {
                    // Conversión de fechas a DateTime? (opcional)
                    DateTime? fechaInicioParsed = string.IsNullOrWhiteSpace(FechaInicio) 
                        ? (DateTime?)null 
                        : DateTime.ParseExact(FechaInicio, "yyyy-MM-dd", null);

                    DateTime? fechaFinalParsed = string.IsNullOrWhiteSpace(FechaFinal) 
                        ? (DateTime?)null 
                        : DateTime.ParseExact(FechaFinal, "yyyy-MM-dd", null);

                    // Obteniendo los datos del servicio con los nuevos filtros
                    var data = _TransferenciaService.GetTransferencia(
                        fechaInicioParsed, 
                        fechaFinalParsed, 
                        IdAlmacen, TipoMovimiento);

                    // Creando el archivo Excel en memoria
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Transferencia");

                        // Agrega encabezados
                        worksheet.Cells[1, 1].Value = "Id";
                        worksheet.Cells[1, 2].Value = "IdAlmacenOrigen";
                        worksheet.Cells[1, 3].Value = "IdAlmacenDestino";
                        worksheet.Cells[1, 4].Value = "Insumo";
                        worksheet.Cells[1, 5].Value = "DescripcionInsumo";
                        worksheet.Cells[1, 6].Value = "Cantidad";
                        worksheet.Cells[1, 7].Value = "TipoMovimiento";
                        worksheet.Cells[1, 8].Value = "Estatus";
                        worksheet.Cells[1, 9].Value = "Fecha_registra";
                        worksheet.Cells[1, 10].Value = "Usuario_registra";
                        worksheet.Cells[1, 11].Value = "FechaMovimiento";
                        worksheet.Cells[1, 12].Value = "EntradaSalida";

                        // Iteramos sobre los datos y llenamos el Excel
                        int row = 2;
                        foreach (var item in data)
                        {
                            worksheet.Cells[row, 1].Value = item.Id;
                            worksheet.Cells[row, 2].Value = item.IdAlmacenOrigen;
                            worksheet.Cells[row, 3].Value = item.IdAlmacenDestino;
                            worksheet.Cells[row, 4].Value = item.Insumo;
                            worksheet.Cells[row, 5].Value = item.DescripcionInsumo;
                            worksheet.Cells[row, 6].Value = item.Cantidad;
                            worksheet.Cells[row, 7].Value = item.TipoMovimiento;
                            worksheet.Cells[row, 8].Value = item.Estatus;
                            worksheet.Cells[row, 9].Value = item.Fecha_registra;
                            worksheet.Cells[row, 10].Value = item.Usuario_registra;
                            worksheet.Cells[row, 11].Value = item.FechaMovimiento;
                            worksheet.Cells[row, 12].Value = item.EntradaSalida;
                            row++;
                        }

                        // Configura el estilo del encabezado
                        using (var range = worksheet.Cells[1, 1, 1, 12])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                        }

                        // Ajustar las columnas al contenido
                        worksheet.Cells.AutoFitColumns();

                        // Guarda el archivo en un arreglo de bytes
                        var excelBytes = package.GetAsByteArray();

                        // Retorna el archivo como una descarga
                        return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TransferenciasReporte.xlsx");
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
        

        [HttpPut("UpdateTransferencias")]
        public IActionResult UpdateTransferencia([FromBody] UpdateTransferenciaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _TransferenciaService.UpdateTransferenciaModel(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteTransferencia/{id}")]
        public IActionResult DeleteTransferencia([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _TransferenciaService.DeleteTransferencias(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}