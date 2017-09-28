﻿using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._Admin.Controllers
{
    public class ArticleController : Controller
    {

        ArticleRepository AR = new ArticleRepository();

        public ActionResult List()
        {
            var model = AR.SelectAllArticles();

            return View(model);
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Article model)
        {
            if (AR.NewArticle(model))
                return RedirectToAction("List", "Article", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Makale Eklenemedi.";
                return View(model);
            }

        }

        public ActionResult Delete(int id)
        {
            if (AR.RemoveArticle(id))
                return RedirectToAction("List", "Article", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Makale Silinemedi.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var model = AR.SelectArticlebyID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Article model)
        {

            if (AR.EditArticle(model))
                return RedirectToAction("List", "Article", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Makale Düzenlenemedi.";
                return View();
            }
        }

    }
}