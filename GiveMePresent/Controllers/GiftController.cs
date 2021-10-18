using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Helpers;
using DataAccess;
using DataAccess.Repository;
using GiveMePresent.Common;
using GiveMePresent.Models;

namespace GiveMePresent.Controllers
{
    [Authorize]
    public class GiftController : Controller
    {
        GiftRepository repo = new GiftRepository();
        GiftedPersonRepository repoPerson = new GiftedPersonRepository();
        // GET: Gift
        public ActionResult Index()
        {
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
            if (!ModelState.IsValid)
            {
                return View(gift);
            }

            if (gift.PresentIMG != null)
            {
                WebImage image = new WebImage(fileBase.InputStream);
                gift.PresentIMG = image.GetBytes();
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
            return View();
        }


    }
}