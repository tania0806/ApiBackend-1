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
using System.Data; // Agrega esta línea


namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class DetalleEntradaController: ControllerBase
    {
   
        private readonly DetalleEntradaService _DetalleEntradaService;
        private readonly ILogger<DetalleEntradaController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public DetalleEntradaController(DetalleEntradaService DetalleEntradaService, ILogger<DetalleEntradaController> logger, IJwtAuthenticationService authService) {
            _DetalleEntradaService = DetalleEntradaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.

            
            
        }


        [HttpPost("InsertDetalleEntrada")]
        public IActionResult InsertDetalleEntrada([FromBody] InsertDetalleEntradaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {   
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _DetalleEntradaService.InsertDetalleEntrada(req);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

[HttpGet("GetDetalleEntrada")] 
public IActionResult GetDetalleEntrada([FromRoute] int id)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var detalles = _DetalleEntradaService.GetDetalleEntrada(id);
        
        objectResponse.StatusCode = (int)HttpStatusCode.OK;
        objectResponse.success = true;
        objectResponse.message = "Datos cargados con éxito";
        objectResponse.data = detalles; // Asigna los datos a la respuesta

    }
    catch (System.Exception ex)
    {
        objectResponse.message = ex.Message;
    }

    return new JsonResult(objectResponse);
}


        [HttpPut("UpdateDetalleEntrada")]
        public IActionResult UpdateDetalleEntrada([FromBody] UpdateDetalleEntradaModel req )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = _DetalleEntradaService.UpdateDetalleEntrada(req);

                ;

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }

        [HttpDelete("DeleteDetalleEntrada/{id}")]
        public IActionResult DeleteDetalleEntrada([FromRoute] int id )
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "data cargado con exito";

                _DetalleEntradaService.DeleteDetalleEntrada(id);

            }

            catch (System.Exception ex)
            {
                objectResponse.message = ex.Message;
            }

            return new JsonResult(objectResponse);
        }
    }
}