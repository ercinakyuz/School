using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            AccessToken = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(AccessToken))
            {
                ForceToLogin();
            }
            return base.OnActionExecutionAsync(context, next);
        }

        public void ForceToLogin()
        {
            string localUrl = Request.Path;
            AccessToken = "";
            HttpContext.Session.SetString("AccessToken", AccessToken);
            if (localUrl != "/account/login")
                Response.Redirect("/account/login?requestedUrl=" + localUrl);
        }



    }
}