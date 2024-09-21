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
//     public class ProfesorController: ControllerBase
//     {
   
//         private readonly ProfesorService _ProfesorService;
//         private readonly ILogger<ProfesorController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public ProfesorController(ProfesorService ProfesorService, ILogger<ProfesorController> logger, IJwtAuthenticationService authService) {
//             _ProfesorService = ProfesorService;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("InsertProfesor")]
//         public IActionResult InsertProfesors([FromBody] InsertProfesorModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _ProfesorService.InsertProfesor(req);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpGet("GetProfesores")]
//         public IActionResult GetProfesores()
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 // Llamando a la función y recibiendo los dos valores.
                
//                  var resultado = _ProfesorService.GetProfesores();
//                  objectResponse.response = resultado;
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpPut("UpdateProfesor")]
//         public IActionResult UpdateProfesores([FromBody] UpdateProfesorModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _ProfesorService.UpdateProfesor(req);

//                 ;

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpDelete("DeleteProfesor/{id}")]
//         public IActionResult DeleteProfesor([FromRoute] int id )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";

//                 _ProfesorService.DeleteProfesor(id);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }
//     }
// }