﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Helpers;
using DataAccess;
using DataAccess.Repository;
using GiveMePresent.Common;
using GiveMePresent.Models;
using Newtonsoft.Json;

namespace GiveMePresent.Controllers
{
    [Authorize]
    public class GiftController : Controller
    {
        GiftRepository repo = new GiftRepository();
        GiftedPersonRepository repoPerson = new GiftedPersonRepository();
        // GET: Gift
        public ActionResult Index(string notification)
        {
            if (notification != null)
            {
                Notification notif = JsonConvert.DeserializeObject<Notification>(notification);
                ViewBag.NType = notif.Type;
                ViewBag.NMessage = notif.Message;
                ViewBag.NTitle = notif.Title;
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gift gift, string Nombre)
        {
            GiftedPerson gifted = new GiftedPerson();

            HttpPostedFileBase fileBase = Request.Files[0];

            if (fileBase.FileName.EndsWith(".jpg"))
            {

                WebImage image = new WebImage(fileBase.InputStream);
                gift.PresentIMG = image.GetBytes();
            }
            else
            {
                ModelState.AddModelError("PresentIMG", "El sistema unicamente acepta imagenes con formato jpg.");
                return View(gift);
            }

            if (!ModelState.IsValid)
            {
                return View(gift);
            }

            Notification notification = new Notification();

            gifted.Email = gift.GiftedPersonEmail;
            gifted.Name = Nombre;

            gift.DateEntry = DateTime.Now;
            gift.UserEmail = User.Identity.Name;
            gift.CodIdf = Tools.RandomString();

            try
            {
                repoPerson.Add(gifted);
                repoPerson.Save();
                repo.Add(gift);
                repo.Save();

                bool check = Tools.SendEmail(gift.GiftedPersonEmail, Nombre, gift.CodIdf, gift.UserEmail);

                notification.Type = "customer-create";
                notification.Message = "Regalo creado y Email enviado con éxito";
                notification.Title = "Regalo";

            }
            catch (Exception ex)
            {
                notification.Type = "customer-warning";
                notification.Message = "No se ha podido mandar el regalo intentelo de nuevo";
                notification.Title = "Warning";
            }
            return RedirectToAction("Index", "Gift", new { notification = JsonConvert.SerializeObject(notification) });
        }


    }
}