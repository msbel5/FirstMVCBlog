using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Data.CustomAuthorization;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._Admin.Controllers
{
    [Authorize]
    [IsAdmin]
    public class UserController : Controller
    {
        
        UserRepository UR = new UserRepository();

        public ActionResult List()
        {
            var model = UR.SelectAllUser();

            return View(model);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User model)
        {
            if (UR.NewUser(model))
                return RedirectToAction("List", "User", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Kullanıcı Eklenemedi.";
                return View(model);
            }

        }

        public ActionResult Delete(int id)
        {
            if (UR.RemoveUser(id))
                return RedirectToAction("List", "User", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Kullanıcı Silinemedi.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var model = UR.SelectUserbyID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {

            if (UR.EditUser(model))
                return RedirectToAction("List", "User", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Kullanıcı Düzenlenemedi.";
                return View();
            }
        }
    }
}