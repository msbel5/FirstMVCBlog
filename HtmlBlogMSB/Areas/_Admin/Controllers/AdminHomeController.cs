using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: _Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}