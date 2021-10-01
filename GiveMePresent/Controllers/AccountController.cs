using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess.DTOs;

namespace GiveMePresent.Controllers
{
    public class AccountController : Controller
    {
        // GET: Accounty
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDTO userLogin)
        {
            //TODO: poner en el layout el fontawesome y preparar estos viewbag x si no hay coincidencia de user.
            ViewBag.Warning = "fa fa-exclamation-triangle";
            ViewBag.LoginFail = "Usuario y/o contraseña incorrecto";
            return null;
        }
    }
}