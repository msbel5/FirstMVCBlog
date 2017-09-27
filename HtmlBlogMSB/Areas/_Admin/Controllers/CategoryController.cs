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

        // GET: Category
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category model)
        {
            if (CR.NewCategory(model))
                return View(model);
            else
            {
                ViewBag.Message = "Kategori Eklenemedi.";
                return View(model);
            }
            
        }

        public ActionResult Delete(int id)
        {
           if(CR.RemoveCategory(id))
            return RedirectToAction("List", "Category");
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

            var data = db.Categories.Find(model.CategoryID);
            data.CategoryName = model.CategoryName;
            data.Description = model.Description;

            db.SaveChanges();

            return View(model);
        }
    }
}