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
    public class DetalleRecetaController: ControllerBase
    {
   
        private readonly DetalleRecetaService _DetalleRecetaService;
        private readonly ILogger<DetalleRecetaController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public DetalleRecetaController(DetalleRecetaService DetalleRecetaService, ILogger<DetalleRecetaController> logger, IJwtAuthenticationService authService) {
            _DetalleRecetaService = DetalleRecetaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertDetalleReceta")]
        public IActionResult InsertDetalleReceta([FromBody] InsertDetalleRecetaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _DetalleRecetaService.InsertDetalleReceta(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

         [HttpGet("GetDetalleReceta")]
        public IActionResult GetDetalleReceta([FromQuery] int IdReceta)
        {
           try
    {
        // Obtener las recetas
        var recetas = _DetalleRecetaService.GetDetalleReceta(IdReceta);
        
        // Verificar si hay recetas
        if (recetas == null || recetas.Count == 0)
        {
            return NotFound("No se encontraron detalle de recetas.");
        }

        // Crear un nuevo archivo Excel
        using (var package = new ExcelPackage())
        {
            // Crear una hoja de trabajo en el archivo Excel
            var worksheet = package.Workbook.Worksheets.Add("DetalleRecetasId");

            // Crear el encabezado
            worksheet.Cells[1, 1].Value = "ID";
            worksheet.Cells[1, 2].Value = "IdReceta";
            worksheet.Cells[1, 3].Value = "Insumo";
            worksheet.Cells[1, 4].Value = "DescripcionInsumo";
            worksheet.Cells[1, 5].Value = "Cantidad";
            worksheet.Cells[1, 6].Value = "Usuario Registra";


            worksheet.Cells[1, 1, 1, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 1, 1, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkGray);

            // Rellenar los datos
            int row = 2; // Comenzar desde la fila 2 para los datos
            foreach (var receta in recetas)
            {
                worksheet.Cells[row, 1].Value = receta.Id;
                worksheet.Cells[row, 2].Value = receta.IdReceta;
                worksheet.Cells[row, 3].Value = receta.Insumo;
                worksheet.Cells[row, 4].Value = receta.DescripcionInsumo;
                 worksheet.Cells[row, 5].Value = receta.Cantidad;
                worksheet.Cells[row, 6].Value = receta.UsuarioRegistra;
                row++;
            }

            // Establecer un nombre para el archivo Excel
            var file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "DetalleReceta.xlsx"));

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

        [HttpPut("UpdateDetalleReceta")]
        public IActionResult UpdateDetalleReceta([FromBody] UpdateDetalleRecetaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _DetalleRecetaService.UpdateDetalleReceta(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteDetalleReceta/{id}")]
        public IActionResult DeleteDetalleReceta([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _DetalleRecetaService.DeleteDetalleReceta(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}