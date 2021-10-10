using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Helpers;
using DataAccess;

namespace GiveMePresent.Controllers
{

    [Authorize]
    public class GiftController : Controller
    {
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
            return View();
        }
    }
}