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
//     public class CalificacionController: ControllerBase
//     {
   
//         private readonly CalificacionService _CalificacionService;
//         private readonly ILogger<CalificacionController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public CalificacionController(CalificacionService CalificacionService, ILogger<CalificacionController> logger, IJwtAuthenticationService authService) {
//             _CalificacionService = CalificacionService;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("InsertCalificacion")]
//         public IActionResult InsertCalificacions([FromBody] InsertCalificacionModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _CalificacionService.InsertCalificacion(req);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpGet("GetCalificaciones")]
//         public IActionResult GetCalificacions()
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 // Llamando a la función y recibiendo los dos valores.
                
//                  var resultado = _CalificacionService.GetCalificacions();
//                  objectResponse.response = resultado;
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpPut("UpdateCalificacion")]
//         public IActionResult UpdateCalificacions([FromBody] UpdateCalificacionModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _CalificacionService.UpdateCalificacion(req);

//                 ;

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpDelete("DeleteCalificacion/{id}")]
//         public IActionResult DeleteCalificacion([FromRoute] int id )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";

//                 _CalificacionService.DeleteCalificacion(id);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }
//     }
// }