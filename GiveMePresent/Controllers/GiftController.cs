using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}