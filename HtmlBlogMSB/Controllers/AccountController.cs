﻿using HtmlBlogMSB.Models.Data;
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
            if (DataModel!=null)
            {
                if (DataModel.Password == model.Password)
                {
                    FormsAuthentication.SetAuthCookie(DataModel.ID.ToString(), model.RememberMe);
                    if (DataModel.IsAdmin)
                        return RedirectToAction("Index", "AdminHome", new { area = "_Admin" });
                    else
                        return RedirectToAction("Index", "UserHome", new { area = "_SignedIn" });
                }
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
                if (!string.IsNullOrWhiteSpace(model.Name))                
                    m.Name = model.Name;
                if (!string.IsNullOrWhiteSpace(model.SurName))
                    m.SurName = model.SurName;
                m.ActivationCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
                m.CreatedOn = DateTime.Now;
                m.IsActivated = false;
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
            
            return RedirectToAction("Index", "Home");
        }
    }
}