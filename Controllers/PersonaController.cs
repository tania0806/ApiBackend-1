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
//     public class PersonaController: ControllerBase
//     {
   
//         private readonly PersonaService _personaService;
//         private readonly ILogger<PersonaController> _logger;
  
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IWebHostEnvironment _hostingEnvironment;
        

//         Encrypt enc = new Encrypt();

//         public PersonaController(PersonaService personaService, ILogger<PersonaController> logger, IJwtAuthenticationService authService) {
//             _personaService = personaService;
//             _logger = logger;
       
//             _authService = authService;
//             // Configura la ruta base donde se almacenan los archivos.
//             // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
//         }


//         [HttpPost("InsertPersonas")]
//         public IActionResult InsertPersonas([FromBody] InsertPersonaModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = _personaService.InsertPersona(req);


//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpGet("GetPersonas")]
//         public IActionResult GetPersonas()
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";


//                 // Llamando a la función y recibiendo los dos valores.
                
//                  var resultado = _personaService.GetPersonas();
//                  objectResponse.response = resultado;
//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpPut("UpdatePersonas")]
//         public IActionResult UpdatePersonas([FromBody] UpdatePersonaModel req )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message =  _personaService.UpdatePersona(req);

               

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }

//         [HttpDelete("DeletePersonas/{id}")]
//         public IActionResult DeletePersonas([FromRoute] int id )
//         {
//             var objectResponse = Helper.GetStructResponse();
//             try
//             {
//                 objectResponse.StatusCode = (int)HttpStatusCode.OK;
//                 objectResponse.success = true;
//                 objectResponse.message = "data cargado con exito";

//                 _personaService.DeletePersona(id);

//             }

//             catch (System.Exception ex)
//             {
//                 objectResponse.message = ex.Message;
//             }

//             return new JsonResult(objectResponse);
//         }
//     }
// }