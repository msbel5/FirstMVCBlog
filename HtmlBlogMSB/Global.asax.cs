using HtmlBlogMSB.Models.Data;
using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HtmlBlogMSB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        UserRepository UR = new UserRepository();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //var data = HttpContext.Current.Request.Cookies.Keys;
            //if (data.Count > 0)
            //{
            //    User model = UR.GetCurrentUser();
            //    if (model.IsActivated)
            //    {
            //        if (model.IsAdmin)
            //        {
            //            Response.Redirect("/_Admin/AdminHome/Index");
            //        }
            //        else
            //        {
            //            Response.Redirect("/_SignedIn/UserHome/Index");
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("/Home/NotActivated");
            //    }
            }
        }



}

