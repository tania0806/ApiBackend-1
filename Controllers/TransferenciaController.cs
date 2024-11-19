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
    public class TransferencisController: ControllerBase
    {
   
        private readonly TransferenciaService _TransferenciaService;
        private readonly ILogger<TransferencisController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public TransferencisController(TransferenciaService TransferenciaService, ILogger<TransferencisController> logger, IJwtAuthenticationService authService) {
            _TransferenciaService = TransferenciaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertTransferencia")]
        public IActionResult InsertTransfarencia([FromBody] InsertTransferenciaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _TransferenciaService.InsertTransferencia(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

       [HttpGet("GetTransferencia")]
            public IActionResult GetTransferencia(DateTime FechaInicio, DateTime FechaFinaL, int? IdAlmacen = null)
            {
                var objectResponse = Helper.GetStructResponse();
                
                try
                {
                    // Llamar al servicio con los parámetros necesarios.
                    var resultado = _TransferenciaService.GetTransferencia(FechaInicio, FechaFinaL, IdAlmacen);

                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Datos cargados con éxito.";
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

        [HttpPut("UpdateTransferencias")]
        public IActionResult UpdateTransferencia([FromBody] UpdateTransferenciaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _TransferenciaService.UpdateTransferenciaModel(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteTransferencia/{id}")]
        public IActionResult DeleteTransferencia([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _TransferenciaService.DeleteTransferencias(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}