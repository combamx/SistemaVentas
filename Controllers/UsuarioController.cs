using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SistemaVentasMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SistemaVentasMVC.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace SistemaVentasMVC.Controllers
{
    //[Route("/Usuario")]
    public class UsuarioController : Controller
    {
        private const AccesoUsuarioModel _SessionUsuario = null;

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
        public  IActionResult Autentificar(AccesoUsuarioModel _accesoUsuario)
        {
            try
            {
                accesoUsuario = _accesoUsuario;
                //SignInManager<Usuario> _usuario;

                using (var db = new VentaRealContext())
                {
                    var _usuario = db.Usuarios.Where(u => u.Email == _accesoUsuario.Email && u.Password == _accesoUsuario.Password).FirstOrDefault();

                    if (_usuario != null)
                    {
                        return Ok(_accesoUsuario);
                        //return RedirectToAction("Add", "Usuario");
                    }
                    else
                    {
                        //return RedirectToAction("Login", "Usuario");
                        return RedirectToAction("Add", "Usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }

        }

        [HttpGet]
        [HttpPost]
        [Route("/Usuario/Add", Name = "Add")]
        public async Task<IActionResult> Add(Usuario _usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new VentaRealContext())
                    {
                        _usuario = new Usuario
                        {
                            Nombre = _usuario.Nombre,
                            Apellidos = _usuario.Apellidos,
                            Email = _usuario.Email,
                            Password = General.GetMD5(_usuario.Password),
                        };

                        accesoUsuario = (AccesoUsuarioModel) _usuario;

                        var addUser = db.Usuarios.Add(_usuario);

                        if(addUser.State == EntityState.Added)
                        {
                            var saveUser = Convert.ToBoolean(db.SaveChanges());

                            if (saveUser)
                            {
                                SessionHelper.SetObjectAsJson(HttpContext.Session, _usuario.Email, _usuario);
                                return RedirectToAction("Index", "Home", new { email = _usuario.Email });
                            }
                            else
                            {
                                return Redirect("/Usuario/Login");
                            }
                        }
                            
                        
                    }
                    //return Ok(_usuario);
                    return Redirect("/Usuario/Login");
                }
                else
                {
                    ViewBag.AccesoUsuario = accesoUsuario;
                    return View();
                }                                           
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }

        public IActionResult Edit()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }

        public IActionResult Delete()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }

        public IActionResult Find()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Redirect("/Home/Error");
            }
        }
    }
}
