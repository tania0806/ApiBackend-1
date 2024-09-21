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
//     public class GrupoController: ControllerBase
//     {
   
//         private readonly GrupoService _GrupoService;
//         private readonly ILogger<GrupoController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public GrupoController(GrupoService GrupoService, ILogger<GrupoController> logger, IJwtAuthenticationService authService) {
//             _GrupoService = GrupoService;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("InsertGrupo")]
//         public IActionResult InsertGrupos([FromBody] InsertGrupoModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _GrupoService.InsertGrupo(req);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpGet("GetGrupos")]
//         public IActionResult GetGrupos()
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 // Llamando a la función y recibiendo los dos valores.
                
//                  var resultado = _GrupoService.GetGrupos();
//                  objectResponse.response = resultado;
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpPut("UpdateGrupo")]
//         public IActionResult UpdateGrupos([FromBody] UpdateGrupoModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _GrupoService.UpdateGrupo(req);

//                 ;

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpDelete("DeleteGrupo/{id}")]
//         public IActionResult DeleteGrupo([FromRoute] int id )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";

//                 _GrupoService.DeleteGrupo(id);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }
//     }
// }