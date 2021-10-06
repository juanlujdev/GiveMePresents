using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess;
using DataAccess.Repository;
using GiveMePresent.Common;
using GiveMePresent.Models;
using Newtonsoft.Json;

namespace GiveMePresent.Controllers
{
    public class UserController : Controller
    {
        UserRepository repo = new UserRepository();
        //GivemePresentDBEntities aw = new GivemePresentDBEntities();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, string badNotification)
        {
            Notification notification = new Notification();
            if (badNotification != null)
            {
                Notification notif = JsonConvert.DeserializeObject<Notification>(badNotification);
                ViewBag.NType = notif.Type;
                ViewBag.NMessage = notif.Message;
                ViewBag.NTitle = notif.Title;
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            try
            {
                user.Date = DateTime.Now;
                user.Password=Tools.SHA256_Encrypt_hex(user.Password);
                repo.Add(user);
                repo.Save();
                notification.Type = "customer-create";
                notification.Message = "Usuario creado con éxito";
                notification.Title = "Usuario";
                
            }
            catch (Exception ex)
            {
                notification.Type = "customer-warning";
                notification.Message = "Usuario ya existe";
                notification.Title = "Warning";
            }
            return RedirectToAction("Login", "Account", new { notification = JsonConvert.SerializeObject(notification) });
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
