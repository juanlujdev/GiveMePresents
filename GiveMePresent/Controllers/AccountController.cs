using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess;
using DataAccess.DTOs;
using DataAccess.Repository;
using GiveMePresent.Common;
using GiveMePresent.Models;
using Newtonsoft.Json;

namespace GiveMePresent.Controllers
{
    public class AccountController : Controller
    {
        UserRepository repo = new UserRepository();

        // GET: Accounty
        public ActionResult Login(string notification)
        {
            //Notification notification = new Notification();
            if (notification != null)
            {
                Notification notif = JsonConvert.DeserializeObject<Notification>(notification);
                ViewBag.NType = notif.Type;
                ViewBag.NMessage = notif.Message;
                ViewBag.NTitle = notif.Title;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginDTO userLogin)
        {
            User user = null;

            if (!string.IsNullOrWhiteSpace(userLogin.Email) && !string.IsNullOrWhiteSpace(userLogin.Password))
            {
                string hash = Tools.SHA256_Encrypt_hex(userLogin.Password);
                user = repo.Get(userLogin.Password, userLogin.Email);
            }
            //TODO: poner en el layout el fontawesome y preparar estos viewbag x si no hay coincidencia de user.

            if (user == null)
            {
                ViewBag.Warning = "fa fa-exclamation-triangle";
                ViewBag.LoginFail = "Usuario y/o contraseña incorrecto";
                return View();
            }
            else
            {
                //TODO: tener la sesion logueadapara poder pasar entre las diferentes pantalla logueado.
            }
            return null;
        }
    }
}