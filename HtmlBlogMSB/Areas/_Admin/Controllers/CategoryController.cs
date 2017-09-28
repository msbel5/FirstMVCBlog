using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository CR = new CategoryRepository();

        public ActionResult List()
        {
            var model = CR.SelectAllCategory();

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category model)
        {
            if (CR.NewCategory(model))
                return RedirectToAction("List", "Category", new { Area="_Admin" });
            else
            {
                ViewBag.Message = "Kategori Eklenemedi.";
                return View(model);
            }
            
        }

        public ActionResult Delete(int id)
        {
           if(CR.RemoveCategory(id))
            return RedirectToAction("List", "Category", new { Area = "_Admin" });
           else
            {
                ViewBag.Message = "Kategori Silinemedi.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var model = CR.SelectCategorybyID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            
            if (CR.EditCategory(model))
                return RedirectToAction("List", "Category", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Kategori Düzenlenemedi.";
                return View();
            }
        }
    }
}