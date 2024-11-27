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
    public class RecetasController: ControllerBase
    {
   
        private readonly RecetasService _RecetasService;
        private readonly ILogger<RecetasController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public RecetasController(RecetasService RecetasService, ILogger<RecetasController> logger, IJwtAuthenticationService authService) {
            _RecetasService = RecetasService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertReceta")]
         public IActionResult InsertReceta([FromBody] InsertRecetasModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _RecetasService.InsertReceta(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }


        [HttpGet("GetRecetasId")]
public IActionResult GetRecetasId([FromQuery] int Id)
{
    try
    {
        // Obtener las recetas
        var recetas = _RecetasService.GetRecetaId(Id);
        
        // Verificar si hay recetas
        if (recetas == null || recetas.Count == 0)
        {
            return NotFound("No se encontraron recetas.");
        }

        // Crear un nuevo archivo Excel
        using (var package = new ExcelPackage())
        {
            // Crear una hoja de trabajo en el archivo Excel
            var worksheet = package.Workbook.Worksheets.Add("RecetasId");

            // Crear el encabezado
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "Nombre";
            worksheet.Cells[1, 3].Value = "Estatus";
            worksheet.Cells[1, 4].Value = "Fecha de Creación";
            worksheet.Cells[1, 5].Value = "Usuario Registra";


            worksheet.Cells[1, 1, 1, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 1, 1, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkGray);

            // Rellenar los datos
            int row = 2; // Comenzar desde la fila 2 para los datos
            foreach (var receta in recetas)
            {
                worksheet.Cells[row, 1].Value = receta.Id;
                worksheet.Cells[row, 2].Value = receta.Nombre;
                worksheet.Cells[row, 3].Value = receta.Estatus;
                worksheet.Cells[row, 4].Value = receta.FechaCreacion;
                worksheet.Cells[row, 5].Value = receta.UsuarioRegistra;
                row++;
            }

            // Establecer un nombre para el archivo Excel
            var file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "RecetasId.xlsx"));

            // Guardar el archivo Excel en el disco
            package.SaveAs(file);

            // Devolver el archivo como una respuesta de descarga
            return File(file.OpenRead(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RecetasReport.xlsx");
        }
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error al generar el reporte: {ex.Message}");
    }
}


    [HttpGet("GetRecetasFecha")]
public IActionResult GetRecetas([FromQuery] string? fechaInicio = null, [FromQuery] string? Fechafinal = null)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        // Conversión de fechas
        DateTime? fechaInicioParsed = string.IsNullOrWhiteSpace(fechaInicio) 
            ? (DateTime?)null 
            : DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", null);
        DateTime? fechaFinalParsed = string.IsNullOrWhiteSpace(Fechafinal) 
            ? (DateTime?)null 
            : DateTime.ParseExact(Fechafinal, "yyyy-MM-dd", null);

        // Obtener datos
        var data = _RecetasService.GetRecetas(fechaInicioParsed, fechaFinalParsed);

        if (data == null || data.Count == 0)
        {
            return BadRequest("No se encontraron registros para las fechas proporcionadas.");
        }

        // Generar Excel
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Recetas");

            // Encabezados
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "Nombre";
            worksheet.Cells[1, 3].Value = "Estatus";
            worksheet.Cells[1, 4].Value = "FechaCreacion";
            worksheet.Cells[1, 5].Value = "Usuario_registra";

            // Agregar datos
            int row = 2;
            foreach (var item in data)
            {
                worksheet.Cells[row, 1].Value = item.Id;
                worksheet.Cells[row, 2].Value = item.Nombre;
                worksheet.Cells[row, 3].Value = item.Estatus;
                worksheet.Cells[row, 4].Value = item.FechaCreacion;
                worksheet.Cells[row, 5].Value = item.UsuarioRegistra;
                row++;
            }

            // Estilo de encabezado
            using (var range = worksheet.Cells[1, 1, 1, 5])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
            }

            // Retornar archivo Excel
            var excelBytes = package.GetAsByteArray();
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RecetasFechas.xlsx");
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

        [HttpPut("UpdateRecetas")]
        public IActionResult UpdateRecetas([FromBody] UpdateRecetasModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _RecetasService.UpdateRecetas(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteRecetas/{id}")]
        public IActionResult DeleteRecetas([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _RecetasService.DeleteRecetas(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}