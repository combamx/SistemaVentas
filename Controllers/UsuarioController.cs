using Microsoft.AspNetCore.Mvc;
using SistemaVentasMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentasMVC.Controllers
{
    //[Route("/Usuario")]
    public class UsuarioController : Controller
    {
        public static AccesoUsuarioModel accesoUsuario { get; set; }

        //[Route("/Usuario/Index")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("/Usuario/Login")]
        public IActionResult Login()
        {
            ViewBag.AccesoUsuario = accesoUsuario;
            return View();
        }

        [HttpPost]
        [Route("/Usuario/Autentificar", Name = "Autentificar")]
        public IActionResult Autentificar(AccesoUsuarioModel _accesoUsuario)
        {
            try
            {
                accesoUsuario = _accesoUsuario;

                using (var db = new VentaRealContext())
                {
                    var _usuario = db.Usuarios.Where(u => u.Email == _accesoUsuario.Email && u.Password == _accesoUsuario.Password).FirstOrDefault();

                    if (_usuario != null)
                    {
                        return Ok(_accesoUsuario);
                    }
                    else
                    {                           
                        return RedirectToAction("Login", "Usuario");
                    }
                }
            }
            catch(Exception ex)
            {
                return Redirect("/Home/Error");
            }

        }
    }
}
