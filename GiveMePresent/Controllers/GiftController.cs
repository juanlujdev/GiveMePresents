using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Helpers;
using DataAccess;
using DataAccess.Repository;
using GiveMePresent.Common;

namespace GiveMePresent.Controllers
{
    [Authorize]
    public class GiftController : Controller
    {
        GiftRepository repo = new GiftRepository();
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
            HttpPostedFileBase fileBase = Request.Files[0];
            WebImage image = new WebImage(fileBase.InputStream);

            gift.PresentIMG = image.GetBytes();
            gift.DateEntry = DateTime.Now;
            gift.UserEmail = User.Identity.Name;
            gift.CodIdf = Tools.RandomString();
            gift.GiftedPerson.Name = Nombre;
            gift.GiftedPerson.Email = gift.GiftedPersonEmail;

            repo.Add(gift);
            return View();
        }


    }
}