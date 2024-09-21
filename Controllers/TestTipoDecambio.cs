using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reportesApi.Controllers
{
    public class TestTipoDecambio : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
