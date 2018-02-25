using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace School.Web.UI.Controllers
{
    public class BaseController : Controller
    {
        public static IConfiguration Config;
        public static string AccessToken;
        public static string BaseApiUrl;

        public BaseController(IConfiguration config)
        {
            Config = config;
            BaseApiUrl = Config["Api:BaseUrl"];
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            AccessToken = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(AccessToken))
            {
                string localUrl = Request.Path;
                if (localUrl == "/account/login")
                {
                    Response.Redirect("/account/login");
                }
                else
                {
                    Response.Redirect("/account/login?requestedUrl=" + localUrl);
                }
            }
        }

    }
}