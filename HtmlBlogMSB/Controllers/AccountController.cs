using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using HtmlBlogMSB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HtmlBlogMSB.Controllers
{
    public class AccountController : Controller
    {
        UserRepository UR = new UserRepository();

        //Get
        public ActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            
            User DataModel = UR.SelectUserbyEmail(model.Email);
            if (DataModel.Password == model.Password)
            {
                FormsAuthentication.SetAuthCookie(DataModel.UserName, model.RememberMe);

                return RedirectToAction("Index", "Home");
            }           
            

            ViewBag.Message = "Kullanıcı adınız veya parolanızı tekrar giriniz";

            //Kullanıcı Kontrolü eğer var ise kullanıcıya cookie yani oturum aç
            return View();
        }

        //GET
        public ActionResult Register()
        {

            //Kullanıcıyı sisteme kaydet.
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {            
            //validasyondan geçtik mi ?
            //serverside validation
            if (ModelState.IsValid)
            {
                User m = new User();
                m.UserName = model.UserName;
                m.Email = model.Email;
                m.EmailVerify = model.EmailVerify;
                m.Password = model.Password;
                m.PasswordVerify = model.PasswordVerify;
                m.DoB = model.DoB;
                if (String.IsNullOrWhiteSpace(model.Name))                
                    m.Name = model.Name;
                if (String.IsNullOrWhiteSpace(model.SurName))
                    m.SurName = model.SurName;
                m.ActivationCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
                m.CreatedOn = DateTime.Now;
                m.IsActivated = true;
                m.IsAdmin = false;                


                if (UR.NewUser(m))
                    return RedirectToAction("Login", "Account");
                else
                    ViewBag.Message = "Girdiğiniz bilgileri kontrol ediniz.";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            //oturumu sil ve login yönlendir.
            return RedirectToAction("Login", "Account");
        }
    }
}