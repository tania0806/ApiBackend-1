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
    public class EntradasController: ControllerBase
    {
   
        private readonly EntradaService _EntradaService;
        private readonly ILogger<EntradasController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public EntradasController(EntradaService EntradaService, ILogger<EntradasController> logger, IJwtAuthenticationService authService) {
            _EntradaService = EntradaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }

        [HttpPost("InsertEntradas")]
        public IActionResult InsertEntradas([FromBody] InsertEntradaModel req)
            {
                var objectResponse = Helper.GetStructResponse();
                try
                {
                    // Llamar al servicio que devuelve el ID insertado
                    int idInsertado = _EntradaService.InsertEntrada(req);
                    
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Entrada insertada correctamente";
                    objectResponse.data = new { IdInsertado = idInsertado }; // Añadir el ID a los datos de respuesta
                }
                catch (System.Exception ex)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    objectResponse.success = false;
                    objectResponse.message = ex.Message;
                }

                return new JsonResult(objectResponse);
            }


        [HttpGet("GetEntrada")]
        public IActionResult GetEntrada()
            {
                var objectResponse = Helper.GetStructResponse();
                
                try
                {
                    // Intentamos obtener el resultado del servicio.
                    var resultado = _EntradaService.GetEntrada();

                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Datos cargados con éxito";
                    objectResponse.response = resultado;
                }
                catch (FormatException ex)
                {
                    // Manejar error específico de formato
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = false;
                    objectResponse.message = $"Error de formato: {ex.Message}";
                }
                catch (System.Exception ex)
                {
                    // Manejar otros errores
                    objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    objectResponse.success = false;
                    objectResponse.message = $"Ocurrió un error: {ex.Message}";
                }

                return new JsonResult(objectResponse);
            }

        [HttpPut("UpdateEntrada")]
        public IActionResult UpdateEntrada([FromBody] UpdateEntradaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _EntradaService.UpdateEntrada(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteEntrada/{id}")]
        public IActionResult DeleteEntrada([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _EntradaService.DeleteEntrada(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}