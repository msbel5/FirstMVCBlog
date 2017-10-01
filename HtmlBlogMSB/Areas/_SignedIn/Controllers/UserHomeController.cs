using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._SignedIn.Controllers
{
    public class UserHomeController : Controller
    {
        ArticleRepository AR = new ArticleRepository();
        CommentRepository CR = new CommentRepository();
        UserRepository UR = new UserRepository();
        // GET: _SignedIn/UserHome
        [Authorize]
        public ActionResult Index()
        {
            List<Article> model = AR.SelectAllArticles().ToList();

            return View(model);
        }
        [Authorize]
        public ActionResult AboutUs()
        {
            return View();
        }
        [Authorize]
        public ActionResult ContactUs()
        {
            return View();
        }
        [Authorize]
        public ActionResult Article(int ID)
        {
            Article model = AR.SelectArticlebyID(ID);
            List<Comment> Clist = CR.SelectCommentsbyArticle(model).ToList();           

            return View(Tuple.Create(model, Clist));
        }
        [Authorize]
        [HttpPost]
        public ActionResult Article(string Context, string ArticleID)
        {
            Comment Comment = new Comment();
            Comment.ArticleID = Convert.ToInt32(ArticleID);
            Comment.Context = Context;            

            if (CR.NewComment(Comment))
                return RedirectToAction("Article/" + Comment.ArticleID, "UserHome", new { Area = "_SignedIn" });
            else
            {
                ViewBag.Message = "Yorum Eklenemedi.";
                return RedirectToAction("Article/" + Comment.ArticleID, "UserHome", new { Area = "_SignedIn" });
            }
        }
    }
}