using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._SignedIn.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: _SignedIn/UserHome
        public ActionResult Index()
        {
            return View();
        }
    }
}