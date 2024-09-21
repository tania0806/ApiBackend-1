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
//     public class GrupoMateriaController: ControllerBase
//     {
   
//         private readonly GrupoMateriaService _GrupoMateriaService;
//         private readonly ILogger<GrupoMateriaController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public GrupoMateriaController(GrupoMateriaService GrupoMateriaService, ILogger<GrupoMateriaController> logger, IJwtAuthenticationService authService) {
//             _GrupoMateriaService = GrupoMateriaService;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("InsertGrupoMateria")]
//         public IActionResult InsertGrupoMateria([FromBody] InsertGrupoMateriaModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _GrupoMateriaService.InsertGrupoMateria(req);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpGet("GetGruposMaterias")]
//         public IActionResult GetGruposMaterias()
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 // Llamando a la función y recibiendo los dos valores.
                
//                  var resultado = _GrupoMateriaService.GetGrupoMateria();
//                  objectResponse.response = resultado;
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpPut("UpdateGrupoMateria")]
//         public IActionResult UpdateGruposMaterias([FromBody] UpdateGrupoMateriaModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _GrupoMateriaService.UpdateGrupoMateria(req);

//                 ;

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpDelete("DeleteGrupoMateria/{id}")]
//         public IActionResult DeleteGrupoMateria([FromRoute] int id )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";

//                 _GrupoMateriaService.DeleteGrupoMateria(id);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }
//     }
// }