using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionHorario.Controllers;
using GestionHorario.Models;

namespace GestionHorario.Filtros
{
    public class VeryfySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var oUser = (Usuario)HttpContext.Current.Session["User"];
            
            //var permisos = (Perfil)HttpContext.Current.Session["Perfil"];
            if (oUser == null)
            {
                if (filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Index");
                }
            }
            else
            {
                
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                                                          
                }
                
            }

            base.OnActionExecuting(filterContext);
        }
    }
}