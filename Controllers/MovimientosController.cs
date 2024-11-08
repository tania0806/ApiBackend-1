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
using System.Linq;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class MovimientosController: ControllerBase
    {
   
        private readonly MovimientosService _MovimientosService;
        private readonly ILogger<MovimientosController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public MovimientosController(MovimientosService MovimientosService, ILogger<MovimientosController> logger, IJwtAuthenticationService authService) {
            _MovimientosService = MovimientosService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertMovimientos")]
         public IActionResult InsertMovimientos([FromBody] InsertMovimientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MovimientosService.InsertMovimientos(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetMovimientos")]
        public IActionResult GetMovimientos([FromQuery] int IdTipoMovimiento)
        {
            {
            var objectResponse = Helper.GetStructResponse();
             

            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Existencia cargados exitosamente";
               var resultado = _MovimientosService.GetMovimientos(IdTipoMovimiento);
               
               

                // Llamando a la función y recibiendo los dos valores.
               
                 objectResponse.response = resultado;
            }

            catch (System.Exception ex)
            {
              objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
              objectResponse.success = false;
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    
        }

        [HttpPut("UpdateMovimientos")]
        public IActionResult UpdateMovimientos([FromBody] UpdateMovimientosModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _MovimientosService.UpdateMovimientos(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteMovimientos/{id}")]
        public IActionResult DeleteMovimientos([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _MovimientosService.DeleteMovimientos(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}