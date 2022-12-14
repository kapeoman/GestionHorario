using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionHorario.Models;
using GestionHorario.Models.View;

namespace GestionHorario.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            using (GestionHorariosEntities bd = new GestionHorariosEntities())
            {
                LoginView login = new LoginView();

                return View(login);
            }
            
        }

        public ActionResult Login(LoginView login)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                using (GestionHorariosEntities bd = new GestionHorariosEntities())
                {
                    

                    response.Error = false;
                    response.Mensaje = "Se ha logeado Correcatamente";
                    var lst = bd.Usuario.Where(x=>x.Persona.Email == login.Email && x.Password == login.Pass);

                    if (lst.Any())
                    {
                        Usuario oUsuario = lst.First();
                        Session["User"] = oUsuario;
                        Session["Perfil"] = null;
                    }
                    else
                    {
                        response.Mensaje = "Login Incorrecto";
                        response.Error = true;
                    }
                    
                    return Json(response);
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Mensaje = ex.Message;
                return Json(response);
            }

            
        }

        public ActionResult CerrarSession()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Acceso");
        }
    }
}
