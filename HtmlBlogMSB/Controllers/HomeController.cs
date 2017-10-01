using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Controllers
{
    public class HomeController : Controller
    {
        ArticleRepository AR = new ArticleRepository();
        CommentRepository CR = new CommentRepository();
        
        public ActionResult Index()
        {
            List<Article> model = AR.SelectAllArticles().ToList();

            return View(model);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Article(int ID)
        {
            Article model = AR.SelectArticlebyID(ID);
            List<Comment> Clist = CR.SelectCommentsbyArticle(model).ToList();
            return View(Tuple.Create(model,Clist));
        }
        public ActionResult NotActivated()
        {
            return View();
        }
    }
}