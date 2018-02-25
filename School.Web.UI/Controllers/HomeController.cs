using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace School.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IConfiguration config) : base(config)
        {
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
