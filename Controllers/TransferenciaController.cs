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
using System.Globalization;

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

//        [HttpGet("GetTransferencia")]
// public IActionResult GetTransferencia(
//      [FromQuery] string? FechaInicio = null,
//     [FromQuery] string? FechaFinal = null,
//     [FromQuery] int? IdAlmacen = null,
//     [FromQuery] int? TipoMovimiento = null,
//     [FromQuery] bool GenerarExcel = false)
// {
//     var objectResponse = Helper.GetStructResponse();

//     try
//     {
//         // Inicializar variables para fechas
//         DateTime parsedFechaInicio = default;
//         DateTime parsedFechaFinal = default;

//         // Validar y convertir fechas
//         DateTime? fechaInicioParsed = null;
//         if (!string.IsNullOrWhiteSpace(FechaInicio) && 
//             !DateTime.TryParseExact(FechaInicio, "yyyy-MM-dd", null, DateTimeStyles.None, out parsedFechaInicio))
//         {
//             return BadRequest("FechaInicio tiene un formato inválido. Debe ser yyyy-MM-dd.");
//         }
//         else if (!string.IsNullOrWhiteSpace(FechaInicio))
//         {
//             fechaInicioParsed = parsedFechaInicio;
//         }

//         DateTime? fechaFinalParsed = null;
//         if (!string.IsNullOrWhiteSpace(FechaFinal) && 
//             !DateTime.TryParseExact(FechaFinal, "yyyy-MM-dd", null, DateTimeStyles.None, out parsedFechaFinal))
//         {
//             return BadRequest("FechaFinal tiene un formato inválido. Debe ser yyyy-MM-dd.");
//         }
//         else if (!string.IsNullOrWhiteSpace(FechaFinal))
//         {
//             fechaFinalParsed = parsedFechaFinal;
//         }

//         // Obtener datos del servicio
//         var data = _TransferenciaService.GetTransferencia(fechaInicioParsed, fechaFinalParsed, IdAlmacen, TipoMovimiento);

//         if (GenerarExcel)
//         {
//             // Generar Excel
//             using (var package = new ExcelPackage())
//             {
//                 var worksheet = package.Workbook.Worksheets.Add("Transferencia");

//                 // Agrega encabezados
//                 worksheet.Cells[1, 1].Value = "Id";
//                 worksheet.Cells[1, 2].Value = "IdAlmacenOrigen";
//                 worksheet.Cells[1, 3].Value = "IdAlmacenDestino";
//                 worksheet.Cells[1, 4].Value = "Insumo";
//                 worksheet.Cells[1, 5].Value = "DescripcionInsumo";
//                 worksheet.Cells[1, 6].Value = "Cantidad";
//                 worksheet.Cells[1, 7].Value = "TipoMovimiento";
//                 worksheet.Cells[1, 8].Value = "Estatus";
//                 worksheet.Cells[1, 9].Value = "Fecha_registra";
//                 worksheet.Cells[1, 10].Value = "Usuario_registra";
//                 worksheet.Cells[1, 11].Value = "FechaMovimiento";
//                 worksheet.Cells[1, 12].Value = "EntradaSalida";

//                 // Estilos y datos
//                 using (var range = worksheet.Cells[1, 1, 1, 12])
//                 {
//                     range.Style.Font.Bold = true;
//                     range.Style.Fill.PatternType = ExcelFillStyle.Solid;
//                     range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
//                 }

//                 int row = 2;
//                 foreach (var item in data)
//                 {
//                     worksheet.Cells[row, 1].Value = item.Id;
//                     worksheet.Cells[row, 2].Value = item.IdAlmacenOrigen;
//                     worksheet.Cells[row, 3].Value = item.IdAlmacenDestino;
//                     worksheet.Cells[row, 4].Value = item.Insumo;
//                     worksheet.Cells[row, 5].Value = item.DescripcionInsumo;
//                     worksheet.Cells[row, 6].Value = item.Cantidad;
//                     worksheet.Cells[row, 7].Value = item.TipoMovimiento;
//                     worksheet.Cells[row, 8].Value = item.Estatus;
//                     worksheet.Cells[row, 9].Value = item.Fecha_registra;
//                     worksheet.Cells[row, 10].Value = item.Usuario_registra;
//                     worksheet.Cells[row, 11].Value = item.FechaMovimiento;
//                     worksheet.Cells[row, 12].Value = item.EntradaSalida;
//                     row++;
//                 }

//                 worksheet.Cells.AutoFitColumns();
//                 var excelBytes = package.GetAsByteArray();

//                 return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "TransferenciasReporte.xlsx");
//             }
//         }
//         else
//         {
//             objectResponse.data = data;
//             objectResponse.success = true;
//             objectResponse.message = "Datos obtenidos correctamente.";
//             return new JsonResult(objectResponse);
//         }
//     }
//     catch (Exception ex)
//     {
//         objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
//         objectResponse.success = false;
//         objectResponse.message = "Error inesperado: " + ex.Message;
//         return new JsonResult(objectResponse);
//     }
// }

            [HttpGet("GetTransferenciasES")]
                    public IActionResult GetTransferencias(int? IdAlmacen = null, DateTime? fechaInicio = null, DateTime? fechaFinal = null, int? tipoMovimiento = null)
                    {
                        var objectResponse = Helper.GetStructResponse();
                        try
                        {
                            objectResponse.StatusCode = (int)HttpStatusCode.OK;
                            objectResponse.success = true;
                            objectResponse.message = "Transferencias obtenidas con éxito";
                            objectResponse.response = _TransferenciaService.GetTransferencias( IdAlmacen, fechaInicio, fechaFinal, tipoMovimiento);
                        }
                        catch (Exception ex)
                        {
                            objectResponse.message = ex.Message;
                        }
                        return new JsonResult(objectResponse);
                    }
                     [HttpGet("GetTransferenciasES2")]
                    public IActionResult GetT(int? IdAlmacen = null, DateTime? fechaInicio = null, DateTime? fechaFinal = null, int? tipoMovimiento = null)
                    {
                        var objectResponse = Helper.GetStructResponse();
                        try
                        {
                            objectResponse.StatusCode = (int)HttpStatusCode.OK;
                            objectResponse.success = true;
                            objectResponse.message = "Transferencias obtenidas con éxito";
                            objectResponse.response = _TransferenciaService.GetT( IdAlmacen, fechaInicio, fechaFinal, tipoMovimiento);
                        }
                        catch (Exception ex)
                        {
                            objectResponse.message = ex.Message;
                        }
                        return new JsonResult(objectResponse);
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