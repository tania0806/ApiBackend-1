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
    public class TransferenciaController: ControllerBase
    {
   
        private readonly TranferenciaService _TranferenciaService;
        private readonly MovimientoConsultaService _MovimientoConsultaService;
        private readonly ILogger<TransferenciaController> _logger;
  
        private readonly IJwtAuthenticationService _authService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        

        Encrypt enc = new Encrypt();

        public TransferenciaController(TranferenciaService TranferenciaService, MovimientoConsultaService MovimientoConsultaService, ILogger<TransferenciaController> logger, IJwtAuthenticationService authService) {
            _TranferenciaService = TranferenciaService;
            _MovimientoConsultaService = MovimientoConsultaService;
            _logger = logger;
       
            _authService = authService;
            // Configura la ruta base donde se almacenan los archivos.
            // Asegúrate de ajustar la ruta según tu estructura de directorios.
       
            
            
        }
        [HttpPost("RegistrarTransferencia")]
            public IActionResult RegistrarTransferencia([FromBody] TransferenciaModel transferencia)
            {
                try
                {
                    var success = _TranferenciaService.RegistrarTransferencia(transferencia);
                    if (success)
                        return Ok("Transferencia registrada con éxito.");
                    else
                        return BadRequest("Error al registrar la transferencia.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpGet("ConsultarMovimientos")]
            public IActionResult ConsultarMovimientos(int IdAlmacen, DateTime? FechaInicio, DateTime? FechaFin)
            {
                var movimientos = _MovimientoConsultaService.ConsultarMovimientos(IdAlmacen, FechaInicio, FechaFin);
                return Ok(movimientos);
            }


        

    }

}