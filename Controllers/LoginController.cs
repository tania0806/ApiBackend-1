using System;
using Microsoft.AspNetCore.Mvc;
using reportesApi.Services;
using reportesApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using reportesApi.Models;
using Microsoft.Extensions.Logging;
using System.Net;

namespace reportesApi.Controllers
{
   
    [Route("api")]
    public class LoginController: ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly ILogger<LoginController> _logger;
  
        private readonly IJwtAuthenticationService _authService;


        Encrypt enc = new Encrypt();

        public LoginController(LoginService loginservice, ILogger<LoginController> logger, IJwtAuthenticationService authService) {
            _loginService = loginservice;
            _logger = logger;
       
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public JsonResult SignIn([FromBody] InsertUser user)
        {
            ResponseLogin result = new ResponseLogin();
            result.response = new ResponseBody();
            result.response.data = new DataResponseLogin();
            result.response.data.Usuario = new UsuarioModel();
          
                string cryptedPass = enc.GetSHA256(user.Userpassword);
           
            var loginResponse = _loginService.Login(user.Username, user.Userpassword);
            
         
           
                if (loginResponse.Id != 0)
                {
                    result.StatusCode = (int)HttpStatusCode.OK;
                    result.succes = true;
                    result.message = "Bienvenido";
                    result.response.data.Usuario = loginResponse;
                    result.response.data.Status = true;
                    result.response.data.Mensaje = "Bienvenido";
                    var token = _authService.Authenticate(user.Username, cryptedPass);
                    result.response.data.Token = token;
                }
                else
                {
                    result.succes = false;
                    result.message = "Usuario o contraseña incorrecto,";

                }

            
           
          
           
            
            return new JsonResult(result);

        }

    }
}