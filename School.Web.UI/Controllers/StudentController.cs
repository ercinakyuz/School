using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using School.Model.Dto.Api.Student;

namespace School.Web.UI.Controllers
{

    public class StudentController : BaseController
    {
        public StudentController(IConfiguration config) : base(config)
        {
        }

        public async Task<IActionResult> List()
        {
            List<StudentListDto> students = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseApiUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var httpResponse = await httpClient.GetAsync("student/");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<List<StudentListDto>>(jsonString);
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ForceToLogin();
                }
            }
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseApiUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await httpClient.PostAsync("student/", content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    var studentCreated = JsonConvert.DeserializeObject<StudentCreatedDto>(jsonString);
                    return RedirectToAction("Edit", new { id = studentCreated.Id });
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ForceToLogin();
                }
            }
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit(int id)
        {
            StudentDetailDto studentDetail = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseApiUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage httpResponse = await httpClient.GetAsync("student/" + id);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    studentDetail = JsonConvert.DeserializeObject<StudentDetailDto>(jsonString);
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ForceToLogin();
                }
            }
            return View(studentDetail);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentUpdateDto dto)
        {
            StudentUpdatedDto studentUpdated = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseApiUrl);
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AccessToken);
                var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await httpClient.PutAsync("student/", content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    studentUpdated = JsonConvert.DeserializeObject<StudentUpdatedDto>(jsonString);
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ForceToLogin();
                }
            }
            return RedirectToAction("Edit", new { id = dto.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            StudentDeletedDto studentDeleted = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseApiUrl);
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage httpResponse = await httpClient.DeleteAsync("student/" + id);
                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    studentDeleted = JsonConvert.DeserializeObject<StudentDeletedDto>(jsonString);
                }
                else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ForceToLogin();
                }
            }
            return RedirectToAction("List");
        }
    }

}