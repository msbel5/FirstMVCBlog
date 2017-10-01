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
    public class AdminHomeController : Controller
    {        
        ArticleRepository AR = new ArticleRepository();
        CommentRepository CR = new CommentRepository();
        UserRepository UR = new UserRepository();

        // GET: _Admin/AdminHome
        
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
            return View(Tuple.Create(model, Clist));
        }
        [HttpPost]
        public ActionResult Article(string Context, string ArticleID)
        {
            Comment Comment = new Comment();
            Comment.ArticleID = Convert.ToInt32(ArticleID);
            Comment.Context = Context;

            if (CR.NewComment(Comment))
                return RedirectToAction("Article/" + Comment.ArticleID, "AdminHome", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Yorum Eklenemedi.";
                return RedirectToAction("Article/" + Comment.ArticleID, "AdminHome", new { Area = "_Admin" });
            }
        }
    }
}