using HtmlBlogMSB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlBlogMSB.Models.Data.CustomAuthorization
{
    public class IsAdminAttribute : AuthorizeAttribute
    {
        UserRepository UR = new UserRepository();        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            if (UserID > 0)
            {
                User User = UR.GetCurrentUser();
                if (User.IsAdmin)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/_SignedIn/UserHome/Index");
        }
    }
}