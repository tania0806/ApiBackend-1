// using System;
// using Microsoft.AspNetCore.Mvc;
// using reportesApi.Services;
// using reportesApi.Utilities;
// using Microsoft.AspNetCore.Authorization;
// using reportesApi.Models;
// using Microsoft.Extensions.Logging;
// using System.Net;
// using reportesApi.Helpers;
// using Newtonsoft.Json;
// using System.IO;
// using OfficeOpenXml;
// using OfficeOpenXml.Style;
// using Microsoft.AspNetCore.Hosting;
// using reportesApi.Models.Compras;

// namespace reportesApi.Controllers
// {
   
//     [Route("api")]
//     public class ComprasController: ControllerBase
//     {
   
//         private readonly ComprasService _articulosService;
//         private readonly ILogger<ComprasController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public ComprasController(ComprasService articulosservice, ILogger<ComprasController> logger, IJwtAuthenticationService authService) {
//             _articulosService = articulosservice;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("DiasInventario")]
//         public IActionResult ReporteDias([FromBody] GetReporteDiasInventarioModel req )
//         {


//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 var memory = new MemoryStream();
//                 // Llamando a la función y recibiendo los dos valores.
//                 ( memory, string filePath) = _articulosService.ReporteDiasInventario(req.FechaInicial, req.FechaFinal, req.Proveedor);
//                 Console.WriteLine("la ruta es:" + filePath);

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return File(memory, contentType, Path.GetFileName(filePath));
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }


//             return new JsonResult(objectResponse);

//         }

//         [HttpGet("ReporteCatalogoArticulos")]
//         public IActionResult ReporteCatalogoArticulos( [FromQuery  ] int sucursal )
//         {


//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 var memory = new MemoryStream();
//                 // Llamando a la función y recibiendo los dos valores.
//                 ( memory, string filePath) = _articulosService.ReporteCatalogoArticulos(sucursal);
//                 Console.WriteLine("la ruta es:" + filePath);

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return File(memory, contentType, Path.GetFileName(filePath));
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }


//             return new JsonResult(objectResponse);

//         }


//         [HttpPost("FaltantesExistencia")]
//         public IActionResult FaltantesExistencia([FromBody] DifrenciaInventariosReques req )
//         {


//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 var memory = new MemoryStream();
//                 // Llamando a la función y recibiendo los dos valores.
//                 ( memory, string filePath) = _articulosService.ReporteFaltanteExistencias(req.Sucursal);
//                 Console.WriteLine("la ruta es:" + filePath);

//                 // Configura el tipo de contenido correcto según el tipo de archivo.
//                 // Para archivos Excel, puedes usar "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
//                 var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
//                 var fileExt = Path.GetExtension("ReporteDias.xlsx").ToLowerInvariant();
//                 if (fileExt == ".xlsx")
//                 {
//                     contentType = "application/vnd.ms-excel";
//                 }
//                 return File(memory, contentType, Path.GetFileName(filePath));
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }


//             return new JsonResult(objectResponse);

//         }

//     }
// }