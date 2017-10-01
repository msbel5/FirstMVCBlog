using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Data.CustomAuthorization;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HtmlBlogMSB.Areas._Admin.Controllers
{
    [Authorize]
    [IsAdmin]
    public class ProfileController : Controller
    {
        UserRepository UR = new UserRepository();
        CommentRepository CR = new CommentRepository();
        ArticleRepository AR = new ArticleRepository();
        CategoryRepository CaR = new CategoryRepository();

        // GET: _Admin/Profile
        
        public ActionResult MyProfile()
        {
            User CurrentUser = UR.GetCurrentUser();
            List<Article> AList = AR.GetCurrentUserArticles().ToList();
            List<Comment> CList = CR.SelectCommentsbyCurrentUser().ToList();
            return View(Tuple.Create<User,List<Article>,List<Comment>>(CurrentUser,AList,CList));
        }

        
        [HttpGet]
        public ActionResult Account()
        {
            var model = UR.GetCurrentUser();
            return View(model);
        }

        [HttpPost]
        public ActionResult Account(User model)
        {            
            User dataModel = UR.SelectUserbyID(model.ID);            
            model.Email = dataModel.Email;
            model.EmailVerify = dataModel.EmailVerify;
            model.IsActivated = dataModel.IsActivated;
            model.IsAdmin = dataModel.IsAdmin;
            model.Password = dataModel.Password;
            model.PasswordVerify = dataModel.PasswordVerify;
            model.UserName = dataModel.UserName;
            model.ActivationCode = dataModel.ActivationCode;
            model.CreatedOn = dataModel.CreatedOn;            
            if (UR.EditUser(model))
                return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Ayarlarınız değiştirilemedi.";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Security()
        {
            var model = UR.GetCurrentUser();
            return View(model);
        }

        [HttpPost]
        public ActionResult Security(string OPassword, string NPassword, string NVPassword)
        {
            User model = UR.GetCurrentUser();
            if (model.Password==OPassword)
            {                
                model.Password = NPassword;
                model.PasswordVerify = NVPassword;
                if (UR.EditUser(model))
                    return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
                else
                {
                    ViewBag.Message = "Ayarlarınız değiştirilemedi.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Ayarlarınız değiştirilemedi.";
                return View();
            }

        }



        public ActionResult CommentDelete(int id)
        {
            if (CR.RemoveComments(id))
                return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Yorum Silinemedi.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult CommentEdit(int ID)
        {

            var model = CR.SelectCommentbyID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult CommentEdit(Comment model)
        {
            if (CR.EditComment(model))
                return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Yorum Düzenlenemedi.";
                return View();
            }
        }


        public ActionResult ArticleDelete(int id)
        {
            
            if (AR.RemoveArticle(id))
                return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Makale Silinemedi.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ArticleEdit(int ID)
        {
            CategoryRepository CR = new CategoryRepository();
            List<SelectListItem> CList = CR.SelectAllCategory().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()

            }).ToList();
            ViewBag.Clist = CList;
            var model = AR.SelectArticlebyID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult ArticleEdit(Article model, int[] CID)
        {
            List<CategoryArticle> CAlist = new List<CategoryArticle>();
            foreach (var item in CID)
            {
                Category CModel = CaR.SelectCategorybyID(item);
                CAlist.Add(new CategoryArticle { ArticleId = model.ID, CategoryId = CModel.ID });
            }
            if (AR.EditArticle(model, CAlist))
                return RedirectToAction("MyProfile", "Profile", new { Area = "_Admin" });
            else
            {
                ViewBag.Message = "Makale Düzenlenemedi.";
                return View();
            }
        }

        public ActionResult DeleteMe()
        {
            int UserID = UR.GetCurrentUser().ID;
            FormsAuthentication.SignOut();            
            if (UR.RemoveUser(UserID))
                return RedirectToAction("Index", "Home", new {Area="" });
            else
            {
                ViewBag.Message = "Kaydınız Silinemedi.";
                return View();
            }
        }
    }
}