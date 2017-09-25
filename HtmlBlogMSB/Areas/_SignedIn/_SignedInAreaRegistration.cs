using System.Web.Mvc;

namespace HtmlBlogMSB.Areas._SignedIn
{
    public class _SignedInAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "_SignedIn";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "_SignedIn_default",
                "_SignedIn/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}