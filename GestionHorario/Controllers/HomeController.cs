using GestionHorario.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionHorario.Controllers
{
    public class HomeController : Controller
    {
        MetodoUsuario metodoUsuario = new MetodoUsuario();
        public ActionResult Index()
        {
            var oUser = metodoUsuario.GetUsuario();
            if (oUser != null)
            {
                if (!oUser.PassModificada)
                {
                    return RedirectToAction("cambiarPass", "Usuario");
                }
            }                      
            return View();
        }
        
    }
}