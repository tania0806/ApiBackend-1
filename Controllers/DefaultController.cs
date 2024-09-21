// using System;
// using System.Net.Http;
// using reportesApi.Models;
// using reportesApi.Services;
// using Microsoft.AspNetCore.Authorization;

// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace reportesApi.Controllers
// {
//  [Route("api")]
//     public class DefaultController:ControllerBase
//     {
//         private readonly ILogger<DefaultController> _logger;
//         private readonly IJwtAuthenticationService _authService;
//         private readonly IHttpClientFactory _clientFactory;

//         public DefaultController(ILogger<DefaultController> logger, IJwtAuthenticationService authService, IHttpClientFactory clientFactory)
//         {
//             _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//             _authService = authService;
//             _clientFactory = clientFactory;
//         }

//         [AllowAnonymous]
//         [HttpPost("authenticate")]
//         public JsonResult Authenticate([FromBody] AuthInfo user)
//         {
//             var token = _authService.Authenticate(user.Username, user.IdUsername);

//             if (token == null)
//             {
//                 return new JsonResult(new { data = (string)null });
//             }

//             return new JsonResult(new { data = token });
//         }
//     }
// }
