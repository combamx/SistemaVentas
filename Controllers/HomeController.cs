using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaVentasMVC.Library;
using SistemaVentasMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string email)
        {
            AccesoUsuarioModel _usuario = SessionHelper.GetObjectFromJson<AccesoUsuarioModel>(HttpContext.Session, email);
            if (_usuario != null && _usuario.Email != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Usuario/Login");
            }

        }

        public IActionResult Privacy()
        {
            return Redirect("/Usuario/Login");
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
