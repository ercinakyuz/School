using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using School.Model.Dto.Member;

namespace School.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Login(string requestedUrl)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginDto dto, string requestedUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_config["Api:BaseUrl"]);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var httpResponse = await httpClient.PostAsync("login", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonMember = await httpResponse.Content.ReadAsStringAsync();
                    var member = JsonConvert.DeserializeObject<MemberDto>(jsonMember);
                    HttpContext.Session.SetString("AccessToken", member.Token);
                    return string.IsNullOrEmpty(requestedUrl) ? Redirect("/") : Redirect(requestedUrl);
                }
                else
                {
                    HttpContext.Session.SetString("AccessToken", "");
                    TempData["ErrorMessage"] = "Geçersiz kullanıcı!";
                    return RedirectToAction("Login");
                }
            }
        }
    }
}